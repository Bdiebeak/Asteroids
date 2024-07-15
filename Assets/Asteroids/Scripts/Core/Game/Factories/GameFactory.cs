using System.Collections.Generic;
using Asteroids.Scripts.Core.Game.Behaviours;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Utilities.Pool;
using Asteroids.Scripts.Core.Utilities.Services.Assets;
using Asteroids.Scripts.DI.Container;
using Asteroids.Scripts.DI.Unity.Extensions;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Factories
{
	// TODO: refactoring
	public class GameFactory : IGameFactory
	{
		private readonly IContainer _container;
		private readonly IAssetProvider _assetProvider;
		private readonly Dictionary<string, IPool> _pools = new();

		public GameFactory(IContainer container, IAssetProvider assetProvider)
		{
			_container = container;
			_assetProvider = assetProvider;
		}

		public Camera CreateMainCamera()
		{
			GameObject camera = InstantiateWithPrefabValues(GameAssetKeys.MainCamera);
			return camera.GetComponent<Camera>();
		}

		public void CreatePlayerView(Entity entity)
		{
			EntityView view = CreateView(GameAssetKeys.Player, entity.Get<PositionComponent>().value, entity.Get<RotationComponent>().value);
			view.Construct(entity);
		}

		public void CreateAsteroidView(Entity entity)
		{
			EntityView view = CreateView(GameAssetKeys.Asteroid, entity.Get<PositionComponent>().value);
			view.Construct(entity);
		}

		public void CreateAsteroidPieceView(Entity entity)
		{
			EntityView view = CreateView(GameAssetKeys.AsteroidPiece, entity.Get<PositionComponent>().value);
			view.Construct(entity);
		}

		public void CreateUfoView(Entity entity)
		{
			EntityView view = CreateView(GameAssetKeys.Ufo, entity.Get<PositionComponent>().value);
			view.Construct(entity);
		}

		public void CreateBulletView(Entity entity)
		{
			EntityView view = CreateView(GameAssetKeys.Bullet, entity.Get<PositionComponent>().value);
			view.Construct(entity);
		}

		public void CreateLaserView(Entity entity)
		{
			EntityView view = CreateView(GameAssetKeys.Laser, entity.Get<PositionComponent>().value, entity.Get<RotationComponent>().value);
			view.Construct(entity);
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

		public EntityView CreateView(string assetKey, Vector3 position, float rotation = 0)
		{
			GameObject prefab = _assetProvider.Load<GameObject>(assetKey);
			GameObject instance = GetInstance(prefab, position, Quaternion.Euler(0, 0, rotation));
			return instance.GetComponent<EntityView>();
		}

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
				poolable.Initialize(pool);
				Transform poolableTransform = poolable.transform;
				poolableTransform.position = position;
				poolableTransform.rotation = rotation;

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