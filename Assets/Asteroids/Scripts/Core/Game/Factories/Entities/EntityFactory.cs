using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Owner.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.Score.Components;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Factories.Entities
{
	public class EntityFactory : IEntityFactory
	{
		private Entity _player;
		private readonly GameplayContext _gameplayContext;
		private readonly IConfigService _configService;

		public EntityFactory(GameplayContext gameplayContext, IConfigService configService)
		{
			_gameplayContext = gameplayContext;
			_configService = configService;
		}

		public Entity CreatePlayer(Vector2 position)
		{
			PlayerConfig playerConfig = _configService.PlayerConfig;
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new PlayerComponent());
			entity.Add(new PositionComponent()).value = position;
			entity.Add(new MoveDirectionComponent());
			entity.Add(new MoveSpeedComponent()).value = playerConfig.moveSpeed;
			entity.Add(new MoveVelocityComponent());
			entity.Add(new MoveAccelerationComponent()).value = playerConfig.moveAcceleration;
			entity.Add(new MoveDecelerationComponent()).value = playerConfig.moveDeceleration;
			entity.Add(new RotationComponent());
			entity.Add(new RotationDirectionComponent());
			entity.Add(new RotationSpeedComponent()).value = playerConfig.rotationSpeed;
			entity.Add(new RotationVelocityComponent());
			entity.Add(new KeepInBoundsComponent());
			entity.Add(new BulletWeaponReference()).value = CreateBulletWeapon(entity);
			entity.Add(new LaserWeaponReference()).value = CreateLaserWeapon(entity);
			entity.Add(new ScoreCounterComponent());
			_player = entity;
			return entity;
		}

		public Entity CreateAsteroid(Vector2 position, Vector2 moveDirection)
		{
			AsteroidConfig asteroidConfig = _configService.AsteroidConfig;
			AsteroidPieceConfig pieceConfig = _configService.AsteroidPieceConfig;
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new EnemyComponent());
			entity.Add(new AsteroidComponent());
			entity.Add(new PiecesComponent()).value = pieceConfig.spawnCount;
			entity.Add(new PositionComponent()).value = position;
			entity.Add(new MoveDirectionComponent()).value = moveDirection;
			entity.Add(new MoveSpeedComponent()).value = asteroidConfig.speed;
			entity.Add(new MoveVelocityComponent());
			entity.Add(new KeepInBoundsComponent());
			entity.Add(new ScoreRewardComponent()).value = asteroidConfig.score;
			return entity;
		}

		public Entity CreateAsteroidPiece(Vector2 position, Vector2 moveDirection)
		{
			AsteroidPieceConfig pieceConfig = _configService.AsteroidPieceConfig;
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new EnemyComponent());
			entity.Add(new AsteroidPieceComponent());
			entity.Add(new PositionComponent()).value = position;
			entity.Add(new MoveDirectionComponent()).value = moveDirection;
			entity.Add(new MoveSpeedComponent()).value = pieceConfig.speed;
			entity.Add(new MoveVelocityComponent());
			entity.Add(new KeepInBoundsComponent());
			entity.Add(new ScoreRewardComponent()).value = pieceConfig.score;
			return entity;
		}

		public Entity CreateUfo(Vector2 position)
		{
			UfoConfig ufoConfig = _configService.UfoConfig;
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new EnemyComponent());
			entity.Add(new UfoComponent());
			entity.Add(new PositionComponent()).value = position;
			entity.Add(new MoveDirectionComponent());
			entity.Add(new MoveSpeedComponent()).value = ufoConfig.speed;
			entity.Add(new MoveVelocityComponent());
			entity.Add(new KeepInBoundsComponent());
			entity.Add(new ChaseTargetComponent()).value = _player;
			entity.Add(new ScoreRewardComponent()).value = ufoConfig.score;
			return entity;
		}

		public Entity CreateUfoSpawner(float spawnTimer)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new UfoSpawnerComponent());
			entity.Add(new UfoSpawnTimerComponent()).value = spawnTimer;
			return entity;
		}

		public Entity CreateBullet(Vector2 position, Vector2 direction)
		{
			BulletWeaponConfig bulletConfig = _configService.BulletWeaponConfig;
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new BulletComponent());
			entity.Add(new PositionComponent()).value = position;
			entity.Add(new MoveDirectionComponent()).value = direction;
			entity.Add(new MoveSpeedComponent()).value = bulletConfig.speed;
			entity.Add(new MoveVelocityComponent());
			return entity;
		}

		public Entity CreateLaser(Vector2 position, float rotation, Entity shooter)
		{
			LaserWeaponConfig laserConfig = _configService.LaserWeaponConfig;
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new LaserComponent());
			entity.Add(new PositionComponent()).value = position;
			entity.Add(new RotationComponent()).value = rotation;
			entity.Add(new CopyTargetPositionComponent()).target = shooter;
			entity.Add(new CopyTargetRotationComponent()).target = shooter;
			entity.Add(new DestroyTimerComponent()).value = laserConfig.activeTime;
			return entity;
		}

		private Entity CreateBulletWeapon(Entity owner)
		{
			BulletWeaponConfig bulletConfig = _configService.BulletWeaponConfig;
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new WeaponComponent());
			entity.Add(new BulletWeaponComponent());
			entity.Add(new AttackDelayComponent()).value = bulletConfig.attackDelay;
			entity.Add(new OwnerReference()).value = owner;
			return entity;
		}

		private Entity CreateLaserWeapon(Entity owner)
		{
			LaserWeaponConfig laserConfig = _configService.LaserWeaponConfig;
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new WeaponComponent());
			entity.Add(new LaserWeaponComponent());
			entity.Add(new AttackDelayComponent()).value = laserConfig.attackDelay;
			entity.Add(new ChargeDelayComponent()).value = laserConfig.chargingTime;
			entity.Add(new ChargesComponent
			{
				value = laserConfig.maxCharges,
				maxValue = laserConfig.maxCharges
			});
			entity.Add(new OwnerReference()).value = owner;
			return entity;
		}
	}
}