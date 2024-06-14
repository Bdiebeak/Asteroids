using Asteroids.Scripts.Core.Gameplay.Input.Components;
using Asteroids.Scripts.Core.Gameplay.Movement.Components;
using Asteroids.Scripts.Core.Gameplay.Player.Components;
using Asteroids.Scripts.Core.Infrastructure.Utilities;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using Vector2 = System.Numerics.Vector2;

namespace Asteroids.Scripts.Core.Gameplay.Input.Systems
{
	public class ApplyMoveInputSystem : IUpdateSystem
	{
		private readonly IContext _inputContext;
		private readonly IContext _gameplayContext;
		private readonly Mask _moveInputMask;
		private readonly Mask _playerMask;

		public ApplyMoveInputSystem(IContext inputContext, IContext gameplayContext)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_moveInputMask = new Mask().Include<MoveInputComponent>();
			_playerMask = new Mask().Include<PlayerComponent>()
										.Include<MoveDirectionComponent>()
										.Include<AngularDirectionComponent>()
										.Include<RotationComponent>();
		}

		public void Update(float deltaTime)
		{
			var inputEntities = _inputContext.GetEntities(_moveInputMask);
			var playerEntities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity inputEntity in inputEntities)
			{
				MoveInputComponent moveInput = inputEntity.Get<MoveInputComponent>();
				foreach (Entity playerEntity in playerEntities)
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