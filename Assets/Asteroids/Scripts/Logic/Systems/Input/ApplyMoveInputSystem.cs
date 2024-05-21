using System.Numerics;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using Asteroids.Scripts.Logic.Components;
using Asteroids.Scripts.Logic.Infrastructure.Utilities;

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
				foreach (Entity playerEntity in playerEntities)
				{
					MoveDirectionComponent moveDirection = playerEntity.Get<MoveDirectionComponent>();
					AngularDirectionComponent angularDirection = playerEntity.Get<AngularDirectionComponent>();
					RotationComponent rotation = playerEntity.Get<RotationComponent>();

					Vector2 relativeDirection = moveInput.value.Rotate(rotation.value);
					moveDirection.value = relativeDirection;
					angularDirection.value = moveInput.value.X;
				}
			}
		}
	}
}