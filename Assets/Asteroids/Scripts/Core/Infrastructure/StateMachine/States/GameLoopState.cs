using Asteroids.Scripts.Core.Gameplay;
using Asteroids.Scripts.Core.Infrastructure.Factories;
using Asteroids.Scripts.Core.Infrastructure.Services.Screens;
using Asteroids.Scripts.Core.UI.Screens;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class GameLoopState : IState
	{
		private readonly IGameFactory _gameFactory;
		private readonly EcsStartup _ecsStartup;
		private readonly IScreenService _screenService;

		public GameLoopState(IGameFactory gameFactory, EcsStartup ecsStartup,
							 IScreenService screenService)
		{
			_gameFactory = gameFactory;
			_ecsStartup = ecsStartup;
			_screenService = screenService;
		}

		public void Enter()
		{
			_gameFactory.CreatePlayer(Vector2.zero); // TODO: should be here?
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