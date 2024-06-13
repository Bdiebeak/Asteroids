using Asteroids.Scripts.DI.Resolver;

namespace Asteroids.Scripts.Core.Infrastructure.Factories
{
	public class GameStatesFactory : IGameStatesFactory
	{
		private readonly IContainerResolver _containerResolver;

		public GameStatesFactory(IContainerResolver containerResolver)
		{
			_containerResolver = containerResolver;
		}

		public TState GetState<TState>()
		{
			return _containerResolver.Resolve<TState>();
		}
	}
}