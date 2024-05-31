using Asteroids.Scripts.DI.Container;
using Asteroids.Scripts.DI.Describers;

namespace Asteroids.Scripts.DI.Builder
{
	public interface IContainerBuilder
	{
		void Register(IDependencyDescriber dependencyDescriber);
		IContainer Build();
	}
}