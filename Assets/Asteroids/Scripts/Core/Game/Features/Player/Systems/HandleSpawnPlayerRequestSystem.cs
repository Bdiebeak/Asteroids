using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Owner.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Requests;
using Asteroids.Scripts.Core.Game.Features.Score.Components;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Player.Systems
{
	public class HandleSpawnPlayerRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;
		private readonly IConfigService _configService;
		private readonly Mask _playerMask;

		public HandleSpawnPlayerRequestSystem(GameplayContext gameplayContext,
											  IGameFactory gameFactory, IConfigService configService)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
			_configService = configService;
			_playerMask = new Mask().Include<PlayerComponent>();
		}

		public void Update()
		{
			var requestEntities = _gameplayContext.GetRequests<SpawnPlayerRequest>();
			var playerEntities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity requestEntity in requestEntities)
			{
				if (playerEntities.Count > 0)
				{
					Debug.LogError("Can't spawn player, there is already some entity.");
					continue;
				}

				SpawnPlayerRequest request = requestEntity.Get<SpawnPlayerRequest>();

				Entity player = _gameplayContext.CreateEntity();
				player.Add(new PlayerComponent());
				player.Add(new PositionComponent()).value = request.position;
				player.Add(new MoveDirectionComponent());
				player.Add(new MoveSpeedComponent()).value = _configService.PlayerConfig.moveSpeed;
				player.Add(new MoveVelocityComponent());
				player.Add(new MoveAccelerationComponent()).value = _configService.PlayerConfig.moveAcceleration;
				player.Add(new MoveDecelerationComponent()).value = _configService.PlayerConfig.moveDeceleration;
				player.Add(new RotationComponent());
				player.Add(new RotationDirectionComponent());
				player.Add(new RotationSpeedComponent()).value = _configService.PlayerConfig.rotationSpeed;
				player.Add(new RotationVelocityComponent());
				player.Add(new KeepInBoundsComponent());
				player.Add(new ScoreCounterComponent());

				Entity bulletWeapon = _gameplayContext.CreateEntity();
				bulletWeapon.Add(new WeaponComponent());
				bulletWeapon.Add(new BulletWeaponComponent());
				bulletWeapon.Add(new AttackDelayComponent()).value = _configService.BulletWeaponConfig.attackDelay;
				bulletWeapon.Add(new OwnerReference()).entityId = player.Id;

				Entity laserWeapon = _gameplayContext.CreateEntity();
				laserWeapon.Add(new WeaponComponent());
				laserWeapon.Add(new LaserWeaponComponent());
				laserWeapon.Add(new AttackDelayComponent()).value = _configService.LaserWeaponConfig.attackDelay;
				laserWeapon.Add(new ChargeDelayComponent()).value = _configService.LaserWeaponConfig.chargingTime;
				laserWeapon.Add(new ChargesComponent
				{
					value = _configService.LaserWeaponConfig.maxCharges,
					maxValue = _configService.LaserWeaponConfig.maxCharges
				});
				laserWeapon.Add(new OwnerReference()).entityId = player.Id;

				player.Add(new BulletWeaponReference()).entityId = bulletWeapon.Id;
				player.Add(new LaserWeaponReference()).entityId = laserWeapon.Id;
				_gameFactory.CreatePlayerView(player);
			}

			_gameplayContext.DestroyRequests<SpawnPlayerRequest>();
		}
	}
}