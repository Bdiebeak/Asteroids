using Asteroids.Scripts.Core.UI;
using Asteroids.Scripts.Core.UI.Base;
using Asteroids.Scripts.Core.UI.Screens;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class GameOverState : IState
	{
		private readonly IScreenService _screenService;
		private readonly IGameStateMachine _stateMachine;

		public GameOverState(IScreenService screenService, IGameStateMachine stateMachine)
		{
			_screenService = screenService;
			_stateMachine = stateMachine;
		}

		public void Enter()
		{
			_screenService.ShowGameOverScreen();
		}

		public void Update() { }
		public void Exit() { }
	}
}