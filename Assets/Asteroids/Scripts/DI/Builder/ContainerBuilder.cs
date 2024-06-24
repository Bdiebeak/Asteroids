using System.Collections.Generic;
using Asteroids.Scripts.DI.Container;
using Asteroids.Scripts.DI.Describers;
using Asteroids.Scripts.DI.Exceptions;

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

		public IContainer Build()
		{
			IContainer container = new SimpleContainer(_dependencyDescribers);
			return container;
		}

		private void ValidateDescriber(IDependencyDescriber dependencyDescriber)
		{
			if (dependencyDescriber.IsValid())
			{
				return;
			}

			throw new RegistrationException($"Dependency doesn't implement or inherit registration type - {dependencyDescriber.RegistrationType}.");
		}
	}
}