using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.UI.Models;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.UI.Systems
{
	public class UpdateGameScreenSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly GameScreenModel _gameScreenModel;
		private readonly Mask _playerMask;

		public UpdateGameScreenSystem(GameplayContext gameplayContext, GameScreenModel gameScreenModel)
		{
			_gameplayContext = gameplayContext;
			_gameScreenModel = gameScreenModel;
			_playerMask = new Mask().Include<PlayerTagComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity entity in entities)
			{
				_gameScreenModel.position = entity.Get<PositionComponent>().value;
				_gameScreenModel.rotation = entity.Get<RotationComponent>().value;
				_gameScreenModel.velocity = entity.Get<VelocityComponent>().value;
				_gameScreenModel.velocityMagnitude = entity.Get<VelocityComponent>().value.magnitude;
			}
		}
	}
}