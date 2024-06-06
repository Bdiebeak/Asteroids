﻿using System;

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

		public bool IsValid()
		{
			return RegistrationType.IsAssignableFrom(ImplementationType);
		}
	}
}