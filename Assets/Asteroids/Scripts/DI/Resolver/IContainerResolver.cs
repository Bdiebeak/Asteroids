using System;

namespace Asteroids.Scripts.DI.Resolver
{
	public interface IContainerResolver
	{
		TBinding Resolve<TBinding>();
		object Resolve(Type type);
		void InjectInto(object target);
	}
}