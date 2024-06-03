using Asteroids.Scripts.DI.Container;

namespace Asteroids.Scripts.Logic.Infrastructure.StateMachine
{
	// TODO: interface
	public class GameStatesFactory
	{
		private IContainer _container;

		public GameStatesFactory(IContainer container)
		{
			_container = container;
		}

		public TState GetState<TState>()
		{
			return _container.Resolve<TState>();
		}
	}
}