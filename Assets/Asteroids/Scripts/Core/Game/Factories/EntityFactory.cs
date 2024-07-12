using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Owners.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.Score.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Factories
{
	public class EntityFactory : IEntityFactory
	{
		private readonly GameplayContext _gameplayContext;
		private Entity _player;

		public EntityFactory(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
		}

		public Entity CreatePlayer(Vector2 position, float speed, float rotationSpeed,
								   float acceleration, float deceleration, int maxLaserCharges)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new PlayerMarker());
			entity.Add(new Position()).value = position;
			entity.Add(new MoveDirection());
			entity.Add(new MoveSpeed()).value = speed;
			entity.Add(new MoveVelocity());
			entity.Add(new MoveAcceleration()).value = acceleration;
			entity.Add(new MoveDeceleration()).value = deceleration;
			entity.Add(new Rotation());
			entity.Add(new RotationDirection());
			entity.Add(new RotationSpeed()).value = rotationSpeed;
			entity.Add(new RotationVelocity());
			entity.Add(new KeepInBoundsMarker());
			entity.Add(new BulletWeapon()).value = CreateBulletWeapon(entity);
			entity.Add(new LaserWeapon()).value = CreateLaserWeapon(entity);
			entity.Add(new ScoreCounter());
			_player = entity;
			return entity;
		}

		public Entity CreateAsteroid(Vector2 position, Vector2 moveDirection, float speed, int score)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new EnemyMarker());
			entity.Add(new AsteroidMarker());
			entity.Add(new Position()).value = position;
			entity.Add(new MoveDirection()).value = moveDirection;
			entity.Add(new MoveSpeed()).value = speed;
			entity.Add(new MoveVelocity());
			entity.Add(new KeepInBoundsMarker());
			entity.Add(new ScorePoints()).value = score;
			return entity;
		}

		public Entity CreateAsteroidPiece(Vector2 position, Vector2 moveDirection, float speed, int score)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new EnemyMarker());
			entity.Add(new AsteroidPieceMarker());
			entity.Add(new Position()).value = position;
			entity.Add(new MoveDirection()).value = moveDirection;
			entity.Add(new MoveSpeed()).value = speed;
			entity.Add(new MoveVelocity());
			entity.Add(new KeepInBoundsMarker());
			entity.Add(new ScorePoints()).value = score;
			return entity;
		}

		public Entity CreateUfo(Vector2 position, float speed, int score)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new EnemyMarker());
			entity.Add(new UfoMarker());
			entity.Add(new Position()).value = position;
			entity.Add(new MoveDirection());
			entity.Add(new MoveSpeed()).value = speed;
			entity.Add(new MoveVelocity());
			entity.Add(new KeepInBoundsMarker());
			entity.Add(new ChaseTarget()).value = _player;
			entity.Add(new ScorePoints()).value = score;
			return entity;
		}

		public Entity CreateBullet(Vector2 position, Vector2 direction, float speed)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new BulletMarker());
			entity.Add(new Position()).value = position;
			entity.Add(new MoveDirection()).value = direction;
			entity.Add(new MoveSpeed()).value = speed;
			entity.Add(new MoveVelocity());
			return entity;
		}

		public Entity CreateLaser(Vector2 position, float rotation, Entity shooter, float destroyTime)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new LaserMarker());
			entity.Add(new Position()).value = position;
			entity.Add(new Rotation()).value = rotation;
			entity.Add(new CopyTargetPosition()).target = shooter;
			entity.Add(new CopyTargetRotation()).target = shooter;
			entity.Add(new DestroyAtTime()).value = destroyTime;
			return entity;
		}

		// TODO: use ChargeTime and AttackDelay as params during creation
		private Entity CreateBulletWeapon(Entity owner)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new WeaponMarker());
			entity.Add(new BulletWeaponMarker());
			entity.Add(new Owner()).value = owner;
			return entity;
		}

		private Entity CreateLaserWeapon(Entity owner)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new WeaponMarker());
			entity.Add(new LaserWeaponMarker());
			entity.Add(new Charges()).value = WeaponsConfig.LaserCharges;
			entity.Add(new MaxCharges()).value = WeaponsConfig.LaserCharges;
			entity.Add(new Owner()).value = owner;
			return entity;
		}
	}
}