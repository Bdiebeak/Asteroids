using System;

namespace Asteroids.Scripts.DI.Container
{
	public interface IContainer : IDisposable
	{
		TBinding Resolve<TBinding>();
		object Resolve(Type type);
		void InjectInto(object target);
		object CreateInstance(Type implementationType);
		T CreateInstance<T>();
	}
}