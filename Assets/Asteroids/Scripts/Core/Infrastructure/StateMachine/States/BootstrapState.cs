using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Utilities.Services.GameCamera;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class BootstrapState : BaseState
	{
		private readonly IGameStateMachine _stateMachine;
		private readonly IGameFactory _gameFactory;
		private readonly ICameraService _cameraService;

		public BootstrapState(IGameStateMachine stateMachine, IGameFactory gameFactory,
							  ICameraService cameraService)
		{
			_stateMachine = stateMachine;
			_gameFactory = gameFactory;
			_cameraService = cameraService;
		}

		public override void Enter()
		{
			InitializeServices();
			_stateMachine.Enter<GameStartState>();
		}

		private void InitializeServices()
		{
			Camera mainCamera = _gameFactory.CreateMainCamera();
			_cameraService.Initialize(mainCamera);
		}
	}
} 