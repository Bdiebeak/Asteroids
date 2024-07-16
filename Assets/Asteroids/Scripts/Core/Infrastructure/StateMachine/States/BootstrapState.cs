using Asteroids.Scripts.Core.Utilities.Services.GameCamera;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class BootstrapState : BaseState
	{
		private readonly IGameStateMachine _stateMachine;
		private readonly ICameraService _cameraService;

		public BootstrapState(IGameStateMachine stateMachine, ICameraService cameraService)
		{
			_stateMachine = stateMachine;
			_cameraService = cameraService;
		}

		public override void Enter()
		{
			InitializeServices();
			_stateMachine.Enter<GameStartState>();
		}

		private void InitializeServices()
		{
			_cameraService.Initialize(Camera.main);
		}
	}
} 