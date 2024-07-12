using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Input.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
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
			_inputMask = new Mask().Include<RotationInputComponent>();
			_playerMask = new Mask().Include<PlayerComponent>();
		}

		public void Update()
		{
			var inputEntities = _inputContext.GetEntities(_inputMask);
			var playerEntities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity inputEntity in inputEntities)
			{
				RotationInputComponent rotationInput = inputEntity.Get<RotationInputComponent>();

				foreach (Entity playerEntity in playerEntities)
				{
					RotationDirectionComponent rotationDirection = playerEntity.Get<RotationDirectionComponent>();
					rotationDirection.value = rotationInput.value;
				}
			}
		}
	}
}