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
			if (dependencyDescriber.IsValid())
			{
				return;
			}

			throw new InvalidOperationException($"Dependency in describer doesn't implement or inherit registration type - {dependencyDescriber.RegistrationType}.");
		}
	}
}