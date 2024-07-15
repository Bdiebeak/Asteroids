using System.Collections.Generic;
using Asteroids.Scripts.Core.Game.Behaviours;
using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories.EntityBuilders;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Utilities.Pool;
using Asteroids.Scripts.Core.Utilities.Services.Assets;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.DI.Container;
using Asteroids.Scripts.DI.Unity.Extensions;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Factories
{
	public class GameFactory : IGameFactory
	{
		private readonly IContainer _container;
		private readonly GameplayContext _gameplayContext;
		private readonly IAssetProvider _assetProvider;
		private readonly IConfigService _configService;
		private readonly Dictionary<string, IPool> _pools = new();
		private Entity _playerEntity;

		public GameFactory(IContainer container, GameplayContext gameplayContext,
						   IAssetProvider assetProvider, IConfigService configService)
		{
			_container = container;
			_gameplayContext = gameplayContext;
			_assetProvider = assetProvider;
			_configService = configService;
		}

		public Camera CreateMainCamera()
		{
			GameObject camera = InstantiateWithPrefabValues(GameAssetKeys.MainCamera);
			return camera.GetComponent<Camera>();
		}

		public void CreatePlayer(Vector2 position)
		{
			GameObject player = Instantiate(GameAssetKeys.Player, position, 0);
			Entity playerEntity = new PlayerBuilder(_configService.PlayerConfig,
													_configService.BulletWeaponConfig,
													_configService.LaserWeaponConfig)
								  .With(new PositionComponent { value = position })
								  .Build(_gameplayContext);
			player.GetComponent<EntityView>().Construct(playerEntity);
			_playerEntity = playerEntity;
		}

		public void CreateAsteroid(Vector2 position, Vector2 moveDirection)
		{
			GameObject asteroid = Instantiate(GameAssetKeys.Asteroid, position, 0);
			Entity asteroidEntity = new AsteroidBuilder(_configService.AsteroidConfig)
									.With(new PositionComponent { value = position })
									.With(new MoveDirectionComponent { value = moveDirection })
									.Build(_gameplayContext);
			asteroid.GetComponent<EntityView>().Construct(asteroidEntity);
		}

		public void CreateAsteroidPiece(Vector2 position, Vector2 moveDirection)
		{
			GameObject piece = Instantiate(GameAssetKeys.AsteroidPiece, position, 0);
			Entity pieceEntity = new AsteroidPieceBuilder(_configService.AsteroidPieceConfig)
								 .With(new PositionComponent { value = position })
								 .With(new MoveDirectionComponent { value = moveDirection })
								 .Build(_gameplayContext);
			piece.GetComponent<EntityView>().Construct(pieceEntity);
		}

		public void CreateUfo(Vector2 position)
		{
			GameObject ufo = Instantiate(GameAssetKeys.Ufo, position, 0);
			Entity ufoEntity = new UfoBuilder(_configService.UfoConfig)
							   .With(new PositionComponent { value = position })
							   .With(new ChaseTargetComponent { targetEntityId = _playerEntity.Id })
							   .Build(_gameplayContext);
			ufo.GetComponent<EntityView>().Construct(ufoEntity);
		}

		public void CreateBullet(Vector2 position, Vector2 moveDirection)
		{
			GameObject bullet = Instantiate(GameAssetKeys.Bullet, position, 0);
			Entity bulletEntity = new BulletBuilder(_configService.BulletWeaponConfig)
								  .With(new PositionComponent { value = position })
								  .With(new MoveDirectionComponent { value = moveDirection })
								  .Build(_gameplayContext);
			bullet.GetComponent<EntityView>().Construct(bulletEntity);
		}

		public void CreateLaser(Vector2 position, float rotation, int shooterId)
		{
			GameObject laser = Instantiate(GameAssetKeys.Laser, position, 0);
			Entity laserEntity = new LaserBuilder(_configService.LaserWeaponConfig)
								 .With(new PositionComponent { value = position })
								 .With(new RotationComponent { value = rotation })
								 .With(new CopyTargetPositionComponent { targetEntityId = shooterId })
								 .With(new CopyTargetRotationComponent { targetEntityId = shooterId })
								 .Build(_gameplayContext);
			laser.GetComponent<EntityView>().Construct(laserEntity);
		}

		/// <summary>
		/// This function spawns prefab and changes its Transform values.
		/// </summary>
		/// <param name="prefabKey"> Prefab key to load it via AssetProvider. </param>
		/// <param name="position"> New instance position. </param>
		/// <param name="rotation"> New instance rotation. </param>
		/// <param name="parent"> New instance parent. </param>
		/// <returns> New created object. </returns>
		private GameObject Instantiate(string prefabKey, Vector2 position, float rotation, Transform parent = null)
		{
			GameObject prefab = _assetProvider.Load<GameObject>(prefabKey);
			GameObject instance = GetInstance(prefab, position, Quaternion.Euler(0, 0, rotation));
			return instance;
		}

		/// <summary>
		/// This function spawns prefab and doesn't change its default Transform values.
		/// </summary>
		/// <param name="prefabKey"> Prefab key to load it via AssetProvider. </param>
		/// <param name="parent"> New instance parent. </param>
		/// <returns> New created object. </returns>
		private GameObject InstantiateWithPrefabValues(string prefabKey, Transform parent = null)
		{
			GameObject prefab = _assetProvider.Load<GameObject>(prefabKey);
			GameObject instance = Object.Instantiate(prefab, parent);
			_container.InjectGameObject(instance);
			return instance;
		}

		// TODO: refactoring
		private GameObject GetInstance(GameObject prefab, Vector3 position, Quaternion rotation)
		{
			string prefabKey = prefab.name;
			if (prefab.TryGetComponent(out PoolableObject _))
			{
				if (_pools.TryGetValue(prefabKey, out IPool pool) == false)
				{
					pool = new SimplePool(() => InstantiateView(prefab).GetComponent<PoolableObject>());
					_pools[prefabKey] = pool;
				}

				PoolableObject poolable = pool.Get();
				Transform poolableTransform = poolable.transform;
				poolableTransform.position = position;
				poolableTransform.rotation = rotation;
				poolable.Initialize(pool);
				return poolable.gameObject;
			}

			return InstantiateView(prefab, position, rotation);
		}

		private GameObject InstantiateView(GameObject prefab)
		{
			GameObject instance = Object.Instantiate(prefab);
			_container.InjectGameObject(instance);
			return instance;
		}

		private GameObject InstantiateView(GameObject prefab, Vector3 position, Quaternion rotation)
		{
			GameObject instance = Object.Instantiate(prefab, position, rotation);
			_container.InjectGameObject(instance);
			return instance;
		}
	}
}