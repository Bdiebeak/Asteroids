using System;
using Asteroids.Scripts.DI.Container;

namespace Asteroids.Scripts.DI.Describers
{
	public interface IDependencyDescriber
	{
		Lifetime Lifetime { get; }
		Type RegistrationType { get; }
	}
}