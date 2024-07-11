using System.Collections.Generic;
using Asteroids.Scripts.Core.Game.Behaviours;
using Asteroids.Scripts.Core.Utilities.Services.Assets;
using Asteroids.Scripts.DI.Container;
using Asteroids.Scripts.DI.Unity.Extensions;
using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.Scripts.Core.Game.Factories
{
	public class ViewFactory : IViewFactory
	{
		private readonly IAssetProvider _assetProvider;
		private readonly IContainer _container;
		private readonly Dictionary<string, IObjectPool<PoolableObject>> _pools = new();

		public ViewFactory(IAssetProvider assetProvider, IContainer container)
		{
			_assetProvider = assetProvider;
			_container = container;
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
				if (_pools.TryGetValue(prefabKey, out IObjectPool<PoolableObject> pool) == false)
				{
					pool = new ObjectPool<PoolableObject>(() => CreateInstance(prefab).GetComponent<PoolableObject>(),
														  poolable => poolable.OnGet(),
														  poolable => poolable.OnRelease(),
														  poolable => poolable.OnDestroy());
					_pools[prefabKey] = pool;
				}

				PoolableObject poolable = pool.Get();
				Transform poolableTransform = poolable.transform;
				poolableTransform.position = position;
				poolableTransform.rotation = rotation;
				poolable.Initialize(pool);
				return poolable.gameObject;
			}

			return CreateInstance(prefab, position, rotation);
		}

		private GameObject CreateInstance(GameObject prefab)
		{
			GameObject instance = Object.Instantiate(prefab);
			_container.InjectGameObject(instance);
			return instance;
		}

		private GameObject CreateInstance(GameObject prefab, Vector3 position, Quaternion rotation)
		{
			GameObject instance = Object.Instantiate(prefab, position, rotation);
			_container.InjectGameObject(instance);
			return instance;
		}
	}
}