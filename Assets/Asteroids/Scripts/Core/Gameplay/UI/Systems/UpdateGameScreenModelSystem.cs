using Asteroids.Scripts.Core.Gameplay.Contexts;
using Asteroids.Scripts.Core.Gameplay.Movement.Components;
using Asteroids.Scripts.Core.Gameplay.Player.Components;
using Asteroids.Scripts.Core.UI.Models;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Gameplay.UI.Systems
{
	public class UpdateGameScreenModelSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly GameScreenModel _gameScreenModel;
		private readonly Mask _playerMask;

		public UpdateGameScreenModelSystem(GameplayContext gameplayContext, GameScreenModel gameScreenModel)
		{
			_gameplayContext = gameplayContext;
			_gameScreenModel = gameScreenModel;
			_playerMask = new Mask().Include<PlayerComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity entity in entities)
			{
				_gameScreenModel.Score += 1;
				_gameScreenModel.Position = entity.Get<PositionComponent>().value;
				_gameScreenModel.Rotation = entity.Get<RotationComponent>().value;
				_gameScreenModel.Velocity = entity.Get<VelocityComponent>().value;
				_gameScreenModel.VelocityMagnitude = entity.Get<VelocityComponent>().value.magnitude;
			}
		}
	}
}