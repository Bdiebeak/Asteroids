using Asteroids.Scripts.Core.Infrastructure.Services.Screens;
using Asteroids.Scripts.Core.UI.Screens;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class GameOverState : IState
	{
		private readonly IScreenService _screenService;

		public GameOverState(IScreenService screenService)
		{
			_screenService = screenService;
		}

		public void Enter()
		{
			_screenService.Show<GameOverScreen>();
		}

		public void Update() { }
		public void Exit() { }
	}
}