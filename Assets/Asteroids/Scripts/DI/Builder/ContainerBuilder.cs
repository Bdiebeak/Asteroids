using System;
using System.Collections.Generic;
using Asteroids.Scripts.DI.Describers;
using Asteroids.Scripts.DI.Resolver;

namespace Asteroids.Scripts.DI.Builder
{
	public class ContainerBuilder : IContainerBuilder
	{
		private readonly List<IDependencyDescriber> _dependencyDescribers = new();

		public void Register(IDependencyDescriber dependencyDescriber)
		{
			ValidateDescriber(dependencyDescriber);
			_dependencyDescribers.Add(dependencyDescriber);
		}

		public IContainerResolver Build()
		{
			IContainerResolver containerResolver = new ContainerResolver(_dependencyDescribers);
			return containerResolver;
		}

		private void ValidateDescriber(IDependencyDescriber dependencyDescriber)
		{
			switch (dependencyDescriber)
			{
				case InstanceDependencyDescriber instanceDescriber:
					Type instanceType = instanceDescriber.Instance.GetType();
					if (instanceDescriber.RegistrationType.IsAssignableFrom(instanceType) == false)
					{
						throw new InvalidOperationException($"{instanceType} doesn't implement or inherit {instanceDescriber.RegistrationType}.");
					}
					break;

				case TypeDependencyDescriber typeDescriber:
					if (typeDescriber.RegistrationType.IsAssignableFrom(typeDescriber.ImplementationType) == false)
					{
						throw new InvalidOperationException($"{typeDescriber.ImplementationType} doesn't implement or inherit {typeDescriber.RegistrationType}.");
					}
					break;

				default:
					throw new ArgumentOutOfRangeException(nameof(dependencyDescriber));
			}
		}
	}
}