using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Input.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Systems
{
	public class ApplyRotateInputSystem : IUpdateSystem
	{
		private readonly InputContext _inputContext;
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _inputMask;
		private readonly Mask _playerMask;

		public ApplyRotateInputSystem(InputContext inputContext, GameplayContext gameplayContext)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_inputMask = new Mask().Include<RotateInputComponent>();
			_playerMask = new Mask().Include<PlayerTagComponent>();
		}

		public void Update()
		{
			var inputEntities = _inputContext.GetEntities(_inputMask);
			var playerEntities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity inputEntity in inputEntities)
			{
				RotateInputComponent rotateInput = inputEntity.Get<RotateInputComponent>();

				foreach (Entity playerEntity in playerEntities)
				{
					RotationVelocityComponent rotationVelocity = playerEntity.Get<RotationVelocityComponent>();

					// Refill rotation input. Invert for proper rotation.
					rotationVelocity.value = -rotateInput.value * PlayerConfig.shipAngularSpeed;
				}
			}
		}
	}
}