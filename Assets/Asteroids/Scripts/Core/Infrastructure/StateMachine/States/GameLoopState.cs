using Asteroids.Scripts.Core.Game;
using Asteroids.Scripts.Core.UI.Screens;
using Asteroids.Scripts.Core.Utilities.Services.Screens;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class GameLoopState : BaseState
	{
		private readonly EcsStartup _ecsStartup;
		private readonly IScreenService _screenService;

		public GameLoopState(EcsStartup ecsStartup, IScreenService screenService)
		{
			_ecsStartup = ecsStartup;
			_screenService = screenService;
		}

		public override void Enter()
		{
			_screenService.Show<GameScreen>();
			_ecsStartup.Initialize();
			_ecsStartup.Start();
		}

		public override void Update()
		{
			_ecsStartup.Update();
		}

		public override void Exit()
		{
			_ecsStartup.Destroy();
		}
	}
}