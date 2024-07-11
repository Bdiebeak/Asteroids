using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.Score.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Components;
using Asteroids.Scripts.Core.Game.Views;
using Asteroids.Scripts.Core.Utilities.Services.Assets;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.Scripts.Core.Game.Factories
{
	public class GameFactory : IGameFactory
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IPrefabCreator _prefabCreator;
		private Entity _player;

		public GameFactory(GameplayContext gameplayContext, IPrefabCreator prefabCreator)
		{
			_gameplayContext = gameplayContext;
			_prefabCreator = prefabCreator;
		}

		public Camera CreateMainCamera()
		{
			GameObject instance = _prefabCreator.Instantiate(GameAssetKeys.MainCamera);
			return instance.GetComponent<Camera>();
		}

		public Entity CreatePlayer(Vector2 position)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new PlayerMarker());
			entity.Add(new Position()).value = position;
			entity.Add(new MoveDirection());
			entity.Add(new MoveSpeed()).value = PlayerConfig.MoveSpeed;
			entity.Add(new MoveVelocity());
			entity.Add(new MoveAcceleration()).value = PlayerConfig.Acceleration;
			entity.Add(new MoveDeceleration()).value = PlayerConfig.Deceleration;
			entity.Add(new Rotation());
			entity.Add(new RotationDirection());
			entity.Add(new RotationSpeed()).value = PlayerConfig.RotationSpeed;
			entity.Add(new RotationVelocity());
			entity.Add(new KeepInBoundsMarker());
			entity.Add(new LaserCharges()).value = WeaponsConfig.LaserCharges;
			entity.Add(new LaserMaxCharges()).value = WeaponsConfig.LaserCharges;
			entity.Add(new ScoreCounter());

			EntityView view = _prefabCreator.Instantiate(GameAssetKeys.Player, position)
											.GetComponent<EntityView>();
			view.Construct(entity);

			_player = entity;
            return entity;
		}

		public Entity CreateAsteroid(Vector2 position)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new EnemyMarker());
			entity.Add(new AsteroidMarker());
			entity.Add(new Position()).value = position;
			entity.Add(new MoveDirection()).value = Random.insideUnitCircle.normalized;
			entity.Add(new MoveSpeed()).value = EnemiesConfig.AsteroidSpeed;
			entity.Add(new MoveVelocity());
			entity.Add(new KeepInBoundsMarker());
			entity.Add(new ScorePoints()).value = EnemiesConfig.AsteroidScore;

			EntityView view = _prefabCreator.Instantiate(GameAssetKeys.Asteroid, position)
											.GetComponent<EntityView>();
			view.Construct(entity);

			return entity;
		}

		public Entity CreateAsteroidPiece(Vector2 position)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new EnemyMarker());
			entity.Add(new AsteroidPieceMarker());
			entity.Add(new Position()).value = position;
			entity.Add(new MoveDirection()).value = Random.insideUnitCircle.normalized;
			entity.Add(new MoveSpeed()).value = EnemiesConfig.AsteroidPieceSpeed;
			entity.Add(new MoveVelocity());
			entity.Add(new KeepInBoundsMarker());
			entity.Add(new ScorePoints()).value = EnemiesConfig.AsteroidPieceScore;

			EntityView view = _prefabCreator.Instantiate(GameAssetKeys.AsteroidPiece, position)
											.GetComponent<EntityView>();
			view.Construct(entity);

			return entity;
		}

		public Entity CreateUfo(Vector2 position)
		{
			if (_gameplayContext.IsActive(_player) == false)
			{
				Debug.LogError("Can't create UFO because the Player entity isn't active or null.");
				return null;
			}

			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new EnemyMarker());
			entity.Add(new UfoMarker());
			entity.Add(new Position()).value = position;
			entity.Add(new MoveDirection()).value = Random.insideUnitCircle.normalized;
			entity.Add(new MoveSpeed()).value = EnemiesConfig.UfoSpeed;
			entity.Add(new MoveVelocity());
			entity.Add(new KeepInBoundsMarker());
			entity.Add(new ChaseTarget()).value = _player;
			entity.Add(new ScorePoints()).value = EnemiesConfig.UfoScore;

			EntityView view = _prefabCreator.Instantiate(GameAssetKeys.Ufo, position)
											.GetComponent<EntityView>();
			view.Construct(entity);

			return entity;
		}

		public Entity CreateBullet(Vector2 position, Vector2 direction)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new BulletMarker());
			entity.Add(new Position()).value = position;
			entity.Add(new MoveDirection()).value = direction;
			entity.Add(new MoveSpeed()).value = WeaponsConfig.BulletSpeed;
			entity.Add(new MoveVelocity());

			EntityView view = _prefabCreator.Instantiate(GameAssetKeys.Bullet, position)
											.GetComponent<EntityView>();
			view.Construct(entity);

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

			EntityView view = _prefabCreator.Instantiate(GameAssetKeys.Laser, position, rotation)
											.GetComponent<EntityView>();
			view.Construct(entity);

			return entity;
		}
	}
}