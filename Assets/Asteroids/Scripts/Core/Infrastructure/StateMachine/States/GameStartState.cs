using Asteroids.Scripts.Core.Gameplay;
using Asteroids.Scripts.Core.Infrastructure.Factories;
using Asteroids.Scripts.Core.UI.Base;
using Asteroids.Scripts.Core.UI.Screens;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class GameStartState : IState
	{
		private readonly IGameFactory _gameFactory;
		private readonly IUIFactory _uiFactory;
		private readonly IScreenService _screenService;
		private readonly EcsStartup _ecsStartup;

		public GameStartState(IGameFactory gameFactory, IUIFactory uiFactory,
							  IScreenService screenService, EcsStartup ecsStartup)
		{
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
			_screenService = screenService;
			_ecsStartup = ecsStartup;
		}

		public void Enter()
		{
			_gameFactory.CreateMainCamera(); // TODO: should bind into Container.
			_uiFactory.CreateMainCanvas();
			_screenService.Show<GameStartScreen>();
			_ecsStartup.Initialize();
		}

		public void Update() { }
		public void Exit() { }
	}
}