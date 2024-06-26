using Asteroids.Scripts.DI.Container;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine
{
	public class GameStatesFactory : IGameStatesFactory
	{
		private readonly IContainer _container;

		public GameStatesFactory(IContainer container)
		{
			_container = container;
		}

		public TState GetState<TState>()
		{
			return _container.CreateInstance<TState>();
		}
	}
}