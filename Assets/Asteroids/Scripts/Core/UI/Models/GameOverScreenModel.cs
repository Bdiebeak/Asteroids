using Asteroids.Scripts.Core.Infrastructure.Services.Input;
using Asteroids.Scripts.Core.Infrastructure.StateMachine;
using Asteroids.Scripts.Core.Infrastructure.StateMachine.States;

namespace Asteroids.Scripts.Core.UI.Models
{
	public class GameOverScreenModel
	{
		public int Score;

		private readonly IInputService _inputService;
		private readonly IGameStateMachine _gameStateMachine;

		public GameOverScreenModel(IInputService inputService, IGameStateMachine gameStateMachine)
		{
			_inputService = inputService;
			_gameStateMachine = gameStateMachine;
		}

		public void Enable()
		{
			_inputService.StartLevelPressed += RestartGame;
		}

		public void Disable()
		{
			_inputService.StartLevelPressed -= RestartGame;
		}

		public void RestartGame()
		{
			_gameStateMachine.Enter<RestartState>();
		}
	}
}