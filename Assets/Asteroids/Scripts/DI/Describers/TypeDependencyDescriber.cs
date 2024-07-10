using System;

namespace Asteroids.Scripts.DI.Describers
{
	public class TypeDependencyDescriber : IDependencyDescriber
	{
		public Lifetime Lifetime { get; }
		public Type RegistrationType { get; }
		public Type ImplementationType { get; }

		public TypeDependencyDescriber(Lifetime lifetime, Type dependencyType, Type implementationType)
		{
			Lifetime = lifetime;
			RegistrationType = dependencyType;
			ImplementationType = implementationType;
		}

		public bool IsValid()
		{
			return RegistrationType.IsAssignableFrom(ImplementationType);
		}
	}
}