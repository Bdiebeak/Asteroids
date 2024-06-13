using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Asteroids.Scripts.DI.Describers;
using Asteroids.Scripts.DI.Exceptions;

namespace Asteroids.Scripts.DI.Resolver
{
	public class ContainerResolver : IContainerResolver
	{
		private readonly Dictionary<Type, IDependencyDescriber> _describers = new();
		private readonly Dictionary<Type, object> _singletons = new();
		private readonly HashSet<Type> _currentResolves = new();

		public ContainerResolver(IEnumerable<IDependencyDescriber> dependencyDescribers)
		{
			// Register container instance to inject it if needed (into factories or etc).
			_describers.Add(typeof(IContainerResolver), new InstanceDependencyDescriber(typeof(IContainerResolver), this));

			// Register dependencies from builder.
			foreach (IDependencyDescriber dependencyDescriber in dependencyDescribers)
			{
				_describers.Add(dependencyDescriber.RegistrationType, dependencyDescriber);
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

				// Cache instance if it's singleton.
				if (describer.Lifetime == Lifetime.Singleton)
				{
					_singletons.Add(describer.RegistrationType, instance);
				}
				return instance;
			}
			finally
			{
				_currentResolves.Remove(type);
			}
		}

		private object CreateInstance(Type implementationType)
		{
			if (implementationType.IsInterface || implementationType.IsAbstract)
			{
				throw new InstanceCreationException($"{implementationType} cannot be created because it is an interface or an abstract class.");
			}

			ConstructorInfo constructorInfo = implementationType.GetConstructors().FirstOrDefault();
			if (constructorInfo == null)
			{
				throw new InstanceCreationException($"Can't find any available constructor for {implementationType}.");
			}

			ParameterInfo[] parameterInfos = constructorInfo.GetParameters();
			object[] parameters = new object[parameterInfos.Length];
			for (int i = 0; i < parameterInfos.Length; i++)
			{
				parameters[i] = Resolve(parameterInfos[i].ParameterType);
			}

			return constructorInfo.Invoke(parameters);
		}
	}
}