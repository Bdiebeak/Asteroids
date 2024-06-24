using Asteroids.Scripts.Core.Game;
using Asteroids.Scripts.Core.UI.Screens;
using Asteroids.Scripts.Core.Utilities.Services.Screens;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class GameLoopState : IState
	{
		private readonly EcsStartup _ecsStartup;
		private readonly IScreenService _screenService;

		public GameLoopState(EcsStartup ecsStartup, IScreenService screenService)
		{
			_ecsStartup = ecsStartup;
			_screenService = screenService;
		}

		public void Enter()
		{
			_screenService.Show<GameScreen>();
			_ecsStartup.Start();
		}

		public void Update()
		{
			_ecsStartup.Update();
			_ecsStartup.CleanUp();
		}

		public void Exit()
		{
			_ecsStartup.Stop();
		}
	}
}