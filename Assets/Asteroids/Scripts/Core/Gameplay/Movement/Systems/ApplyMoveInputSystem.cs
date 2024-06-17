using Asteroids.Scripts.Core.Gameplay.Input.Components;
using Asteroids.Scripts.Core.Gameplay.Movement.Components;
using Asteroids.Scripts.Core.Gameplay.Player.Components;
using Asteroids.Scripts.Core.Infrastructure.Configs;
using Asteroids.Scripts.Core.Infrastructure.Extensions;
using Asteroids.Scripts.Core.Infrastructure.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Gameplay.Movement.Systems
{
	public class ApplyMoveInputSystem : IUpdateSystem
	{
		private readonly IContext _inputContext;
		private readonly IContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _moveInputMask;
		private readonly Mask _playerMask;

		public ApplyMoveInputSystem(IContext inputContext, IContext gameplayContext, ITimeService timeService)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_moveInputMask = new Mask().Include<MoveInputComponent>()
									   .Include<RotateInputComponent>();
			_playerMask = new Mask().Include<PlayerComponent>()
									.Include<VelocityComponent>()
									.Include<RotationVelocityComponent>()
									.Include<RotationComponent>();
		}

		public void Update()
		{
			var inputEntities = _inputContext.GetEntities(_moveInputMask);
			var playerEntities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity inputEntity in inputEntities)
			{
				MoveInputComponent moveInput = inputEntity.Get<MoveInputComponent>();
				RotateInputComponent rotateInput = inputEntity.Get<RotateInputComponent>();

				foreach (Entity playerEntity in playerEntities)
				{
					VelocityComponent velocity = playerEntity.Get<VelocityComponent>();
					RotationVelocityComponent rotationVelocity = playerEntity.Get<RotationVelocityComponent>();
					RotationComponent rotation = playerEntity.Get<RotationComponent>();

					// Handle only forward movement.
					if (moveInput.value > 0)
					{
						Vector2 moveVector = new(0, moveInput.value);
						Vector2 targetVelocity = moveVector.Rotate(rotation.value).normalized * GameConfig.ShipMaxSpeed;
						velocity.value = Vector2.MoveTowards(velocity.value, targetVelocity,
															 GameConfig.ShipAcceleration * _timeService.DeltaTime);
					}

					// Refill rotation input. Invert for proper rotation.
					rotationVelocity.value = -rotateInput.value * GameConfig.ShipAngularSpeed;
				}
			}
		}
	}
}