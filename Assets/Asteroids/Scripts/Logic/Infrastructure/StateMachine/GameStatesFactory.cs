using Asteroids.Scripts.DI.Resolver;

namespace Asteroids.Scripts.Logic.Infrastructure.StateMachine
{
	// TODO: interface
	public class GameStatesFactory
	{
		private IContainerResolver _containerResolver;

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