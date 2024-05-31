using System;
using Asteroids.Scripts.DI.Container;

namespace Asteroids.Scripts.DI.Describers
{
	public class TypeDependencyDescriber : IDependencyDescriber
	{
		public Lifetime Lifetime { get; private set; }
		public Type RegistrationType { get; private set; }
		public Type ImplementationType { get; private set; }

		public TypeDependencyDescriber(Lifetime lifetime, Type dependencyType, Type implementationType)
		{
			Lifetime = lifetime;
			RegistrationType = dependencyType;
			ImplementationType = implementationType;
		}
	}
}