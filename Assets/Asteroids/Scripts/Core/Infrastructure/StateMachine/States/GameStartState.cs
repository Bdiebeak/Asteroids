using Asteroids.Scripts.Core.UI.Screens;
using Asteroids.Scripts.Core.Utilities.Services.Screens;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class GameStartState : IState
	{
		private readonly IScreenService _screenService;

		public GameStartState(IScreenService screenService)
		{
			_screenService = screenService;
		}

		public void Enter()
		{
			_screenService.Show<GameStartScreen>();
		}

		public void Update() { }
		public void Exit() { }
	}
}