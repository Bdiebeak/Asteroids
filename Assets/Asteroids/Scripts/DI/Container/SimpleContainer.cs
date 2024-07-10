using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Asteroids.Scripts.DI.Attributes;
using Asteroids.Scripts.DI.Describers;
using Asteroids.Scripts.DI.Exceptions;

namespace Asteroids.Scripts.DI.Container
{
	public class SimpleContainer : IContainer
	{
		private readonly Dictionary<Type, IDependencyDescriber> _describers = new();
		private readonly Dictionary<Type, object> _singletons = new();
		private readonly HashSet<Type> _currentResolves = new();
		private readonly HashSet<IDisposable> _disposables = new();

		public SimpleContainer(IEnumerable<IDependencyDescriber> dependencyDescribers)
		{
			// Register container instance to inject it if needed (into factories or etc).
			_describers.Add(typeof(IContainer), new InstanceDependencyDescriber(typeof(IContainer), this));

			// Register dependencies from builder.
			foreach (IDependencyDescriber dependencyDescriber in dependencyDescribers)
			{
				_describers.Add(dependencyDescriber.RegistrationType, dependencyDescriber);
			}
		}

		public void Dispose()
		{
			_disposables.Remove(this); // To avoid infinity loop, cause container is registered too.
			foreach (IDisposable disposable in _disposables)
			{
				disposable.Dispose();
			}
		}

		public TBinding Resolve<TBinding>()
		{
			return (TBinding)Resolve(typeof(TBinding));
		}

		public object Resolve(Type type)
		{
			if (_currentResolves.Contains(type))
			{
				throw new CycleDependencyException($"Cycle dependency was detected for {type.Name}.");
			}

			_currentResolves.Add(type);
			try
			{
				object instance;
				if (_describers.TryGetValue(type, out IDependencyDescriber describer) == false)
				{
					throw new RegistrationException($"Can't find registered describer for {type.Name}.");
				}

				// Try to get existing singleton if needed.
				if (describer.Lifetime == Lifetime.Singleton)
				{
					if (_singletons.TryGetValue(describer.RegistrationType, out instance))
					{
						return instance;
					}
				}

				// Create instance depending on describer.
				switch (describer)
				{
					case InstanceDependencyDescriber instanceDescriber:
						instance = instanceDescriber.Instance;
						break;

					case TypeDependencyDescriber typeDescriber:
						instance = CreateInstance(typeDescriber.ImplementationType);
						break;

					default:
						throw new ArgumentOutOfRangeException(nameof(describer));
				}

				// Cache instance in required fields.
				if (describer.Lifetime == Lifetime.Singleton)
				{
					_singletons.Add(describer.RegistrationType, instance);
				}
				if (instance is IDisposable disposable)
				{
					_disposables.Add(disposable);
				}
				return instance;
			}
			finally
			{
				_currentResolves.Remove(type);
			}
		}

		public void InjectInto(object target)
		{
			Type targetType = target.GetType();
			MethodInfo[] targetMethods = targetType.GetMethods();

			foreach (MethodInfo method in targetMethods)
			{
				InjectAttribute attribute = method.GetCustomAttribute<InjectAttribute>();
				if (attribute == null)
				{
					continue;
				}

				object[] parameters = ResolveParameters(method.GetParameters());
				method.Invoke(target, parameters);
			}
		}

		public T CreateInstance<T>()
		{
			object instance = CreateInstance(typeof(T));
			return (T)instance;
		}

		public object CreateInstance(Type implementationType)
		{
			if (implementationType.IsInterface || implementationType.IsAbstract)
			{
				throw new InstanceCreationException($"{implementationType} cannot be created because it is an interface or an abstract class.");
			}

			object instance;
			ConstructorInfo constructorInfo = implementationType.GetConstructors().FirstOrDefault();
			if (constructorInfo != null)
			{
				object[] parameters = ResolveParameters(constructorInfo.GetParameters());
				instance = constructorInfo.Invoke(parameters);
			}
			else
			{
				instance = Activator.CreateInstance(implementationType);
			}
			InjectInto(instance);

			return instance;
		}

		private object[] ResolveParameters(ParameterInfo[] infos)
		{
			object[] parameters = new object[infos.Length];
			for (int i = 0; i < infos.Length; i++)
			{
				parameters[i] = Resolve(infos[i].ParameterType);
			}
			return parameters;
		}
	}
}