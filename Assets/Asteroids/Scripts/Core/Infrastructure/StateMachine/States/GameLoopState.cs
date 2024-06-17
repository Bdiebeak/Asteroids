using Asteroids.Scripts.Core.Gameplay;
using Asteroids.Scripts.Core.UI.Base;
using Asteroids.Scripts.Core.UI.Screens;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class GameLoopState : IState
	{
		private readonly IScreenService _screenService;
		private readonly EcsStartup _ecsStartup;

		public GameLoopState(IScreenService screenService, EcsStartup ecsStartup)
		{
			_screenService = screenService;
			_ecsStartup = ecsStartup;
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