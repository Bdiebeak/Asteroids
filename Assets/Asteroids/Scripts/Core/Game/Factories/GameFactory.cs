using System.Collections.Generic;
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
using Asteroids.Scripts.DI.Unity.Extensions;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Asteroids.Scripts.Core.Game.Factories
{
	public class GameFactory : IGameFactory
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IContainer _container;
		private readonly IAssetProvider _assetProvider;
		private readonly Dictionary<string, IObjectPool<PoolableObject>> _pools = new();
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

			EntityView view = Instantiate(GameAssetKeys.Player, position, 0).GetComponent<EntityView>();
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
			entity.Add(new MoveSpeed()).value = EnemiesConfig.AsteroidPieceSpeed;
			entity.Add(new MoveVelocity());
			entity.Add(new KeepInBoundsMarker());
			entity.Add(new ScorePoints()).value = EnemiesConfig.AsteroidPieceScore;

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
			entity.Add(new MoveSpeed()).value = EnemiesConfig.UfoSpeed;
			entity.Add(new MoveVelocity());
			entity.Add(new KeepInBoundsMarker());
			entity.Add(new ChaseTarget()).value = _player;
			entity.Add(new ScorePoints()).value = EnemiesConfig.UfoScore;

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
			entity.Add(new MoveSpeed()).value = WeaponsConfig.BulletSpeed;
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

		private GameObject Instantiate(string assetKey, Transform parent = null)
		{
			GameObject prefab = _assetProvider.Load<GameObject>(assetKey);
			return GetInstance(prefab, prefab.transform.position, prefab.transform.rotation, parent);
		}

		private GameObject Instantiate(string assetKey, Vector3 position, Transform parent = null)
		{
			GameObject prefab = _assetProvider.Load<GameObject>(assetKey);
			return GetInstance(prefab, position, prefab.transform.rotation, parent);
		}

		private GameObject Instantiate(string assetKey, Vector3 position, float rotation, Transform parent = null)
		{
			GameObject prefab = _assetProvider.Load<GameObject>(assetKey);
			return GetInstance(prefab, position, Quaternion.Euler(0, 0, rotation), parent);
		}

		private GameObject GetInstance(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			string prefabKey = prefab.name;
			if (prefab.TryGetComponent(out PoolableObject _))
			{
				if (_pools.TryGetValue(prefabKey, out IObjectPool<PoolableObject> pool) == false)
				{
					pool = new ObjectPool<PoolableObject>(() =>
														  {
															  return CreateInstance(prefab, parent).GetComponent<PoolableObject>();
														  },
														  poolable => poolable.OnGet(),
														  poolable => poolable.OnRelease(),
														  poolable => poolable.OnDestroy());
					_pools[prefabKey] = pool;
				}

				PoolableObject poolable = pool.Get();
				poolable.transform.position = position;
				poolable.transform.rotation = rotation;
				poolable.transform.parent = parent;
				poolable.Initialize(pool);
				return poolable.gameObject;
			}

			return CreateInstance(prefab, position, rotation, parent);
		}

		private GameObject CreateInstance(GameObject prefab, Transform parent = null)
		{
			GameObject instance = Object.Instantiate(prefab, parent);
			_container.InjectGameObject(instance);
			return instance;
		}

		private GameObject CreateInstance(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			GameObject instance = Object.Instantiate(prefab, position, rotation, parent);
			_container.InjectGameObject(instance);
			return instance;
		}
	}
}