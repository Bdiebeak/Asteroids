using System;

namespace Asteroids.Scripts.DI.Resolver
{
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class InjectAttribute : Attribute
	{
	}
}