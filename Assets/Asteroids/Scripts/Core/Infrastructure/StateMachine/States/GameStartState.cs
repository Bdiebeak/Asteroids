using Asteroids.Scripts.Core.Game;
using Asteroids.Scripts.Core.UI.Screens;
using Asteroids.Scripts.Core.Utilities.Services.Screens;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class GameStartState : IState
	{
		private readonly IScreenService _screenService;
		private readonly EcsStartup _ecsStartup;

		public GameStartState(IScreenService screenService, EcsStartup ecsStartup)
		{
			_screenService = screenService;
			_ecsStartup = ecsStartup;
		}

		public void Enter()
		{
			_screenService.Show<GameStartScreen>();
			_ecsStartup.Initialize();
		}

		public void Update() { }
		public void Exit() { }
	}
}