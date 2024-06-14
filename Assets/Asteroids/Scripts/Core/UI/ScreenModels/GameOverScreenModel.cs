using Asteroids.Scripts.Core.Infrastructure.Services.Input;
using Asteroids.Scripts.Core.Infrastructure.StateMachine;
using Asteroids.Scripts.Core.Infrastructure.StateMachine.States;

namespace Asteroids.Scripts.Core.UI.ScreenModels
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

		// TODO: subscribe and unsubscribe when screen Shown or Closed.
		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public void Restart()
		{
			_gameStateMachine.Enter<RestartState>();
		}
	}
}