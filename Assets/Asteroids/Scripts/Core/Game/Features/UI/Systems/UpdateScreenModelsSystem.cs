using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.Score.Components;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.Core.UI.Models;
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
		private readonly Mask _playerMask;

		public UpdateScreenModelsSystem(GameplayContext gameplayContext,
										GameScreenModel gameScreenModel, GameOverScreenModel gameOverScreenModel)
		{
			_gameplayContext = gameplayContext;
			_gameScreenModel = gameScreenModel;
			_gameOverScreenModel = gameOverScreenModel;
			_playerMask = new Mask().Include<PlayerComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity entity in entities)
			{
				UpdateScoreData(entity);
				UpdateTransformData(entity);
				UpdateWeaponsData(entity);
			}
		}

		private void UpdateScoreData(Entity player)
		{
			int score = player.Get<ScoreCounterComponent>().value;

			_gameOverScreenModel.score = score;
			_gameScreenModel.score = score;
		}

		private void UpdateTransformData(Entity player)
		{
			Vector2 velocity = player.Get<MoveVelocityComponent>().value;

			_gameScreenModel.position = player.Get<PositionComponent>().value;
			_gameScreenModel.rotation = player.Get<RotationComponent>().value;
			_gameScreenModel.velocity = velocity;
			_gameScreenModel.velocityMagnitude = velocity.magnitude;
		}

		private void UpdateWeaponsData(Entity player)
		{
			LaserWeaponReference laserWeaponReference = player.Get<LaserWeaponReference>();
			if (_gameplayContext.TryGetEntity(laserWeaponReference.entityId, out Entity laserWeapon) == false)
			{
				Debug.LogError("Can't get laser weapon.");
				return;
			}

			ChargesComponent charges = laserWeapon.Get<ChargesComponent>();

			_gameScreenModel.currentLaserCount = charges.value;
			_gameScreenModel.maxLaserCount = charges.maxValue;
			if (laserWeapon.Has<ChargeDelayTimerComponent>())
			{
				ChargeDelayTimerComponent chargeDelayTimer = laserWeapon.Get<ChargeDelayTimerComponent>();
				_gameScreenModel.laserCooldown = chargeDelayTimer.value;
			}
			else
			{
				_gameScreenModel.laserCooldown = 0;
			}
		}
	}
}