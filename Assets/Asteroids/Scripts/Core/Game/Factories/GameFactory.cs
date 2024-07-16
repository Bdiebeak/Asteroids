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

		public void CreatePlayerView(Entity entity)
		{
			CreateView(GameAssetKeys.Player, entity);
		}

		public void CreateAsteroidView(Entity entity)
		{
			CreateView(GameAssetKeys.Asteroid, entity);
		}

		public void CreateAsteroidPieceView(Entity entity)
		{
			CreateView(GameAssetKeys.AsteroidPiece, entity);
		}

		public void CreateUfoView(Entity entity)
		{
			CreateView(GameAssetKeys.Ufo, entity);
		}

		public void CreateBulletView(Entity entity)
		{
			CreateView(GameAssetKeys.Bullet, entity);
		}

		public void CreateLaserView(Entity entity)
		{
			CreateView(GameAssetKeys.Laser, entity);
		}

		private void CreateView(string assetKey, Entity entity)
		{
			Vector2 position = entity.Has<PositionComponent>() ? entity.Get<PositionComponent>().value : Vector2.zero;
			float rotation = entity.Has<RotationComponent>() ? entity.Get<RotationComponent>().value : 0;

			GameObject prefab = _assetProvider.Load<GameObject>(assetKey);
			EntityView entityView = GetViewInstance(prefab, position, Quaternion.Euler(0, 0, rotation)).GetComponent<EntityView>();
			entityView.Construct(entity);
		}

		private GameObject GetViewInstance(GameObject prefab, Vector2 position, Quaternion rotation)
		{
			if (prefab.TryGetComponent(out PoolableObject _) == false)
			{
				return Instantiate(prefab, position, rotation);
			}

			string poolKey = prefab.name;
			if (_pools.TryGetValue(poolKey, out IPool pool) == false)
			{
				pool = new SimplePool(() => Instantiate(prefab).GetComponent<PoolableObject>());
				_pools[poolKey] = pool;
			}

			PoolableObject poolable = pool.Get();
			poolable.Initialize(pool);

			Transform poolableTransform = poolable.transform;
			poolableTransform.position = position;
			poolableTransform.rotation = rotation;

			return poolable.gameObject;

		}

		/// <summary>
		/// This function spawns prefab and doesn't change its default Transform values.
		/// </summary>
		/// <param name="prefab"> Prefab to instantiate. </param>
		/// <returns> New created object. </returns>
		private GameObject Instantiate(GameObject prefab)
		{
			GameObject instance = Object.Instantiate(prefab);
			_container.InjectGameObject(instance);
			return instance;
		}

		/// <summary>
		/// This function spawns prefab and changes its Transform values.
		/// </summary>
		/// <param name="prefab"> Prefab to instantiate. </param>
		/// <param name="position"> Instance position. </param>
		/// <param name="rotation"> Instance rotation. </param>
		/// <returns> New created object. </returns>
		private GameObject Instantiate(GameObject prefab, Vector2 position, Quaternion rotation)
		{
			GameObject instance = Object.Instantiate(prefab, position, rotation);
			_container.InjectGameObject(instance);
			return instance;
		}
	}
}