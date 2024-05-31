using System;
using Asteroids.Scripts.DI.Container;

namespace Asteroids.Scripts.DI.Describers
{
	public class InstanceDependencyDescriber : IDependencyDescriber
	{
		public Lifetime Lifetime { get; private set; }
		public Type RegistrationType { get; private set; }
		public object Instance { get; private set; }

		public InstanceDependencyDescriber(Type dependencyType, object instance)
		{
			Lifetime = Lifetime.Singleton;
			RegistrationType = dependencyType;
			Instance = instance;
		}
	}
}