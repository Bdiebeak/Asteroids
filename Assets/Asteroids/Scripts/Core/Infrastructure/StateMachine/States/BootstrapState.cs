using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Utilities.Services.Camera;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class BootstrapState : IState
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

		public void Enter()
		{
			InitializeServices();
			_stateMachine.Enter<GameStartState>();
		}

		public void Update() { }
		public void Exit() { }

		private void InitializeServices()
		{
			Camera mainCamera = _gameFactory.CreateMainCamera();
			_cameraService.Initialize(mainCamera);
		}
	}
} 