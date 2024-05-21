using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using Asteroids.Scripts.Logic.Components;
using Asteroids.Scripts.Logic.Infrastructure.Utilities;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Asteroids.Scripts.Logic.Systems.Input
{
	public class ApplyMoveInputSystem : IUpdateSystem
	{
		private readonly IContext _inputContext;
		private readonly IContext _gameplayContext;
		private readonly Filter _moveInputFilter;
		private readonly Filter _playerFilter;

		public ApplyMoveInputSystem(IContext inputContext, IContext gameplayContext)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_moveInputFilter = new Filter().Include<MoveInputComponent>();
			_playerFilter = new Filter().Include<PlayerComponent>()
										.Include<MoveDirectionComponent>()
										.Include<AngularDirectionComponent>()
										.Include<RotationComponent>();
		}

		public void Update(float deltaTime)
		{
			var inputEntities = _inputContext.GetEntities(_moveInputFilter);
			var playerEntities = _gameplayContext.GetEntities(_playerFilter);
			foreach (Entity inputEntity in inputEntities)
			{
				MoveInputComponent moveInput = inputEntity.Get<MoveInputComponent>();
				foreach (Entity playerEntity in playerEntities) // TODO: fix multiple enumeration
				{
					MoveDirectionComponent moveDirection = playerEntity.Get<MoveDirectionComponent>();
					AngularDirectionComponent angularDirection = playerEntity.Get<AngularDirectionComponent>();
					RotationComponent rotation = playerEntity.Get<RotationComponent>();

					// Refill movement input. Handle only forward movement.
					if (moveInput.value.Y >= 0)
					{
						Vector2 moveVector = new(0, moveInput.value.Y);
						moveDirection.value = moveVector.Rotate(rotation.value);
					}
					else
					{
						moveDirection.value = Vector2.Zero;
					}

					// Refill rotation input. Invert for proper rotation.
					angularDirection.value = -moveInput.value.X;
				}
			}
		}
	}
}