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
using Asteroids.Scripts.DI.Container;
using Asteroids.Scripts.DI.Extensions;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.Scripts.Core.Game.Factories
{
	public class GameFactory : IGameFactory
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IContainer _container;
		private readonly IAssetProvider _assetProvider;
		private Entity _player;

		public GameFactory(GameplayContext gameplayContext,
						   IContainer container, IAssetProvider assetProvider)
		{
			_gameplayContext = gameplayContext;
			_container = container;
			_assetProvider = assetProvider;
		}

		public Camera CreateMainCamera()
		{
			GameObject instance = Instantiate(GameAssetKeys.MainCamera);
			return instance.GetComponent<Camera>();
		}

		public Entity CreatePlayer(Vector2 position)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new PlayerMarker());
			entity.Add(new Position()).value = position;
			entity.Add(new MoveDirection());
			entity.Add(new MoveSpeed()).value = PlayerConfig.shipMoveSpeed;
			entity.Add(new MoveVelocity());
			entity.Add(new MoveAcceleration()).value = PlayerConfig.shipAcceleration;
			entity.Add(new MoveDeceleration()).value = PlayerConfig.shipDeceleration;
			entity.Add(new Rotation());
			entity.Add(new RotationDirection());
			entity.Add(new RotationSpeed()).value = PlayerConfig.shipRotationSpeed;
			entity.Add(new RotationVelocity());
			entity.Add(new KeepInBoundsMarker());
			entity.Add(new LaserCharges()).value = WeaponsConfig.laserCharges;
			entity.Add(new LaserMaxCharges()).value = WeaponsConfig.laserCharges;
			entity.Add(new ScoreCounter());

			EntityView view = Instantiate(GameAssetKeys.Player, position).GetComponent<EntityView>();
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
			entity.Add(new MoveSpeed()).value = EnemiesConfig.asteroidSpeed;
			entity.Add(new MoveVelocity());
			entity.Add(new KeepInBoundsMarker());
			entity.Add(new ScorePoints()).value = EnemiesConfig.asteroidScore;

			EntityView view = Instantiate(GameAssetKeys.Asteroid, position).GetComponent<EntityView>();
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
			entity.Add(new MoveSpeed()).value = EnemiesConfig.asteroidPieceSpeed;
			entity.Add(new MoveVelocity());
			entity.Add(new KeepInBoundsMarker());
			entity.Add(new ScorePoints()).value = EnemiesConfig.asteroidPieceScore;

			EntityView view = Instantiate(GameAssetKeys.AsteroidPiece, position).GetComponent<EntityView>();
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
			entity.Add(new MoveSpeed()).value = EnemiesConfig.ufoSpeed;
			entity.Add(new MoveVelocity());
			entity.Add(new KeepInBoundsMarker());
			entity.Add(new ChaseTarget()).value = _player;
			entity.Add(new ScorePoints()).value = EnemiesConfig.ufoScore;

			EntityView view = Instantiate(GameAssetKeys.Ufo, position).GetComponent<EntityView>();
			view.Construct(entity);

			return entity;
		}

		public Entity CreateBullet(Vector2 position, Vector2 direction)
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new BulletMarker());
			entity.Add(new Position()).value = position;
			entity.Add(new MoveDirection()).value = direction;
			entity.Add(new MoveSpeed()).value = WeaponsConfig.bulletSpeed;
			entity.Add(new MoveVelocity());

			EntityView view = Instantiate(GameAssetKeys.Bullet, position).GetComponent<EntityView>();
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

			EntityView view = Instantiate(GameAssetKeys.Laser, position, rotation).GetComponent<EntityView>();
			view.Construct(entity);

			return entity;
		}

		private GameObject Instantiate(string assetKey)
		{
			GameObject prefab = _assetProvider.Load<GameObject>(assetKey);
			return _container.InstantiatePrefab(prefab);
		}

		private GameObject Instantiate(string assetKey, Vector2 position)
		{
			GameObject prefab = _assetProvider.Load<GameObject>(assetKey);
			return _container.InstantiatePrefab(prefab, position, Quaternion.identity);
		}

		private GameObject Instantiate(string assetKey, Vector2 position, float rotation)
		{
			GameObject prefab = _assetProvider.Load<GameObject>(assetKey);
			return _container.InstantiatePrefab(prefab, position, Quaternion.Euler(0, 0, rotation));
		}
	}
}