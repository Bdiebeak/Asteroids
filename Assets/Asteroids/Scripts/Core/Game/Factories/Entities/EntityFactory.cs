using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Owner.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.Score.Components;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Components;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Factories.Entities
{
	public class EntityFactory : IEntityFactory
	{
		private readonly GameplayContext _gameplayContext;
		private Entity _player;

		public EntityFactory(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
		}

		public Entity CreatePlayer(Vector2 position, float speed, float rotationSpeed, float acceleration,
								   float deceleration, float bulletAttackRate, float laserAttackRate,
								   float laserChargeTime, int laserCharges)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new PlayerComponent());
			entity.Add(new PositionComponent()).value = position;
			entity.Add(new MoveDirectionComponent());
			entity.Add(new MoveSpeedComponent()).value = speed;
			entity.Add(new MoveVelocityComponent());
			entity.Add(new MoveAccelerationComponent()).value = acceleration;
			entity.Add(new MoveDecelerationComponent()).value = deceleration;
			entity.Add(new RotationComponent());
			entity.Add(new RotationDirectionComponent());
			entity.Add(new RotationSpeedComponent()).value = rotationSpeed;
			entity.Add(new RotationVelocityComponent());
			entity.Add(new KeepInBoundsComponent());
			entity.Add(new BulletWeaponReference()).value = CreateBulletWeapon(entity, bulletAttackRate);
			entity.Add(new LaserWeaponReference()).value = CreateLaserWeapon(entity, laserAttackRate, laserChargeTime, laserCharges);
			entity.Add(new ScoreCounterComponent());
			_player = entity;
			return entity;
		}

		public Entity CreateAsteroid(Vector2 position, Vector2 moveDirection, int piecesCount, float speed, int score)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new EnemyComponent());
			entity.Add(new AsteroidComponent()).piecesCount = piecesCount;
			entity.Add(new PositionComponent()).value = position;
			entity.Add(new MoveDirectionComponent()).value = moveDirection;
			entity.Add(new MoveSpeedComponent()).value = speed;
			entity.Add(new MoveVelocityComponent());
			entity.Add(new KeepInBoundsComponent());
			entity.Add(new ScoreRewardComponent()).value = score;
			return entity;
		}

		public Entity CreateAsteroidPiece(Vector2 position, Vector2 moveDirection, float speed, int score)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new EnemyComponent());
			entity.Add(new AsteroidPieceComponent());
			entity.Add(new PositionComponent()).value = position;
			entity.Add(new MoveDirectionComponent()).value = moveDirection;
			entity.Add(new MoveSpeedComponent()).value = speed;
			entity.Add(new MoveVelocityComponent());
			entity.Add(new KeepInBoundsComponent());
			entity.Add(new ScoreRewardComponent()).value = score;
			return entity;
		}

		public Entity CreateUfo(Vector2 position, float speed, int score)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new EnemyComponent());
			entity.Add(new UfoComponent());
			entity.Add(new PositionComponent()).value = position;
			entity.Add(new MoveDirectionComponent());
			entity.Add(new MoveSpeedComponent()).value = speed;
			entity.Add(new MoveVelocityComponent());
			entity.Add(new KeepInBoundsComponent());
			entity.Add(new ChaseTargetComponent()).value = _player;
			entity.Add(new ScoreRewardComponent()).value = score;
			return entity;
		}

		public Entity CreateUfoSpawner(float spawnTimer)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new UfoSpawnerComponent());
			entity.Add(new UfoSpawnTimerComponent()).value = spawnTimer;
			return entity;
		}

		public Entity CreateBullet(Vector2 position, Vector2 direction, float speed)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new BulletComponent());
			entity.Add(new PositionComponent()).value = position;
			entity.Add(new MoveDirectionComponent()).value = direction;
			entity.Add(new MoveSpeedComponent()).value = speed;
			entity.Add(new MoveVelocityComponent());
			return entity;
		}

		public Entity CreateLaser(Vector2 position, float rotation, Entity shooter, float activeTime)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new LaserComponent());
			entity.Add(new PositionComponent()).value = position;
			entity.Add(new RotationComponent()).value = rotation;
			entity.Add(new CopyTargetPositionComponent()).target = shooter;
			entity.Add(new CopyTargetRotationComponent()).target = shooter;
			entity.Add(new DestroyTimerComponent()).value = activeTime;
			return entity;
		}

		private Entity CreateBulletWeapon(Entity owner, float attackDelay)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new WeaponComponent());
			entity.Add(new BulletWeaponComponent());
			entity.Add(new AttackDelayComponent()).value = attackDelay;
			entity.Add(new OwnerReference()).value = owner;
			return entity;
		}

		private Entity CreateLaserWeapon(Entity owner, float attackDelay, float chargingTime, int charges)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new WeaponComponent());
			entity.Add(new LaserWeaponComponent());
			entity.Add(new AttackDelayComponent()).value = attackDelay;
			entity.Add(new ChargeDelayComponent()).value = chargingTime;
			entity.Add(new ChargesComponent { value = charges, maxValue = charges });
			entity.Add(new OwnerReference()).value = owner;
			return entity;
		}
	}
}