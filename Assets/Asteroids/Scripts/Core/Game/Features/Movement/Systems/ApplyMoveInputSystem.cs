using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Input.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Utilities.Extensions;
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
		private readonly Mask _inputMask;
		private readonly Mask _playerMask;

		public ApplyMoveInputSystem(InputContext inputContext, GameplayContext gameplayContext)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_inputMask = new Mask().Include<MoveInputComponent>();
			_playerMask = new Mask().Include<PlayerComponent>();
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
					MoveDirectionComponent moveDirection = playerEntity.Get<MoveDirectionComponent>();
					RotationComponent rotation = playerEntity.Get<RotationComponent>();
					Vector2 moveVector = new(0, moveInput.value);
					moveDirection.value = moveVector.Rotate(rotation.value).normalized;
				}
			}
		}
	}
}