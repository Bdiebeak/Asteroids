using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Input.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Utilities.Extensions;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Systems
{
	public class ApplyMoveInputSystem : IUpdateSystem
	{
		private readonly InputContext _inputContext;
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _inputMask;
		private readonly Mask _playerMask;

		public ApplyMoveInputSystem(InputContext inputContext, GameplayContext gameplayContext,
									ITimeService timeService)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_inputMask = new Mask().Include<MoveInputComponent>();
			_playerMask = new Mask().Include<PlayerTagComponent>();
		}

		public void Update()
		{
			var inputEntities = _inputContext.GetEntities(_inputMask);
			var playerEntities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity inputEntity in inputEntities)
			{
				MoveInputComponent moveInput = inputEntity.Get<MoveInputComponent>();

				foreach (Entity playerEntity in playerEntities)
				{
					VelocityComponent velocity = playerEntity.Get<VelocityComponent>();
					RotationComponent rotation = playerEntity.Get<RotationComponent>();

					// Handle only forward movement.
					if (moveInput.value > 0)
					{
						Vector2 moveVector = new(0, moveInput.value);
						Vector2 targetVelocity = moveVector.Rotate(rotation.value).normalized * PlayerConfig.shipMaxSpeed;
						velocity.value = Vector2.MoveTowards(velocity.value, targetVelocity,
															 PlayerConfig.shipAcceleration * _timeService.DeltaTime);
					}
				}
			}
		}
	}
}