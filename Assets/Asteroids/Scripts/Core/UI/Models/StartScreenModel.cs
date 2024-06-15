using Asteroids.Scripts.Core.Infrastructure.Services.Input;
using Asteroids.Scripts.Core.Infrastructure.StateMachine;
using Asteroids.Scripts.Core.Infrastructure.StateMachine.States;

namespace Asteroids.Scripts.Core.UI.Models
{
	public class StartScreenModel
	{
		private readonly IInputService _inputService;
		private readonly IGameStateMachine _gameStateMachine;

		public StartScreenModel(IInputService inputService, IGameStateMachine gameStateMachine)
		{
			_inputService = inputService;
			_gameStateMachine = gameStateMachine;
		}

		// TODO: subscribe and unsubscribe when screen Shown or Closed.
		public void Enable()
		{
			_inputService.StartLevelPressed += StartGame;
		}

		public void Disable()
		{
			_inputService.StartLevelPressed -= StartGame;
		}

		public void StartGame()
		{
			_gameStateMachine.Enter<GameLoopState>();
		}
	}
}