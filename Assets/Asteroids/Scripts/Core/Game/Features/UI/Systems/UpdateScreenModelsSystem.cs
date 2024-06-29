using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.Score.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.UI.Models;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.UI.Systems
{
	public class UpdateScreenModelsSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly GameScreenModel _gameScreenModel;
		private readonly GameOverScreenModel _gameOverScreenModel;
		private readonly ITimeService _timeService;
		private readonly Mask _playerMask;

		public UpdateScreenModelsSystem(GameplayContext gameplayContext, GameScreenModel gameScreenModel,
									  GameOverScreenModel gameOverScreenModel, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_gameScreenModel = gameScreenModel;
			_gameOverScreenModel = gameOverScreenModel;
			_timeService = timeService;
			_playerMask = new Mask().Include<PlayerMarker>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity entity in entities)
			{
				int score = entity.Get<ScoreCounter>().value;
				Vector2 velocity = entity.Get<MoveVelocity>().value;

				_gameOverScreenModel.score = score;
				_gameScreenModel.score = score;
				_gameScreenModel.position = entity.Get<Position>().value;
				_gameScreenModel.rotation = entity.Get<Rotation>().value;
				_gameScreenModel.velocity = velocity;
				_gameScreenModel.velocityMagnitude = velocity.magnitude;
				_gameScreenModel.currentLaserCount = entity.Get<LaserCharges>().value;
				_gameScreenModel.maxLaserCount = entity.Get<LaserMaxCharges>().value;
				_gameScreenModel.laserCooldown = entity.Get<LaserChargeTime>().value - _timeService.Time;
			}
		}
	}
}