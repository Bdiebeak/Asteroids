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
	public class ApplyRotationInputSystem : IUpdateSystem
	{
		private readonly InputContext _inputContext;
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _inputMask;
		private readonly Mask _playerMask;

		public ApplyRotationInputSystem(InputContext inputContext, GameplayContext gameplayContext)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_inputMask = new Mask().Include<RotationInput>();
			_playerMask = new Mask().Include<PlayerMarker>();
		}

		public void Update()
		{
			var inputEntities = _inputContext.GetEntities(_inputMask);
			var playerEntities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity inputEntity in inputEntities)
			{
				RotationInput rotationInput = inputEntity.Get<RotationInput>();

				foreach (Entity playerEntity in playerEntities)
				{
					RotationVelocity rotationVelocity = playerEntity.Get<RotationVelocity>();

					// Refill rotation input. Invert for proper rotation.
					rotationVelocity.value = -rotationInput.value * PlayerConfig.shipAngularSpeed;
				}
			}
		}
	}
}