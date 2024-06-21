using Asteroids.Scripts.Core.Infrastructure.StateMachine;
using Asteroids.Scripts.Core.Infrastructure.StateMachine.States;

namespace Asteroids.Scripts.Core.UI.Models
{
	public class StartScreenModel
	{
		private readonly IGameStateMachine _gameStateMachine;

		public StartScreenModel(IGameStateMachine gameStateMachine)
		{
			_gameStateMachine = gameStateMachine;
		}

		public void StartGame()
		{
			_gameStateMachine.Enter<GameLoopState>();
		}
	}
}