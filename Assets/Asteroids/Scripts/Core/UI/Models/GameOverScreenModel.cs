using Asteroids.Scripts.Core.Infrastructure.StateMachine;
using Asteroids.Scripts.Core.Infrastructure.StateMachine.States;

namespace Asteroids.Scripts.Core.UI.Models
{
	public class GameOverScreenModel
	{
		public int score;

		private readonly IGameStateMachine _gameStateMachine;

		public GameOverScreenModel(IGameStateMachine gameStateMachine)
		{
			_gameStateMachine = gameStateMachine;
		}

		public void RestartGame()
		{
			_gameStateMachine.Enter<RestartState>();
		}
	}
}