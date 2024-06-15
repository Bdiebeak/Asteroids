using Asteroids.Scripts.Core.Gameplay;
using Asteroids.Scripts.Core.Infrastructure.Factories;
using Asteroids.Scripts.Core.Infrastructure.Services.Input;
using Asteroids.Scripts.Core.UI;
using Asteroids.Scripts.Core.UI.Base;
using Asteroids.Scripts.Core.UI.Screens;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	// TODO: mb combine with BootstrapState?
	public class GameStartState : IState
	{
		private readonly IGameFactory _gameFactory;
		private readonly IScreenService _screenService;
		private readonly EcsStartup _ecsStartup;

		public GameStartState(IGameFactory gameFactory, IScreenService screenService,
							  EcsStartup ecsStartup)
		{
			_gameFactory = gameFactory;
			_screenService = screenService;
			_ecsStartup = ecsStartup;
		}

		public void Enter()
		{
			// TODO: should bind into Container.
			_gameFactory.CreateMainCamera();
			_screenService.ShowStartScreen();
			_ecsStartup.Initialize();
		}

		public void Update() { }
		public void Exit() { }
	}
}