using Asteroids.Scripts.DI.Describers;
using Asteroids.Scripts.DI.Resolver;

namespace Asteroids.Scripts.DI.Builder
{
	public interface IContainerBuilder
	{
		void Register(IDependencyDescriber dependencyDescriber);
		IContainerResolver Build();
	}
}