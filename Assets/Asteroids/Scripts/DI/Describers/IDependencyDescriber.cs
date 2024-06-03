using System;

namespace Asteroids.Scripts.DI.Describers
{
	public interface IDependencyDescriber
	{
		Lifetime Lifetime { get; }
		Type RegistrationType { get; }
	}
}