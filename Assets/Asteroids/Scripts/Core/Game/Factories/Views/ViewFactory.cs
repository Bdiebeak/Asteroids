﻿using System.Collections.Generic;
using Asteroids.Scripts.Core.Game.Behaviours;
using Asteroids.Scripts.Core.Utilities.Pool;
using Asteroids.Scripts.Core.Utilities.Services.Assets;
using Asteroids.Scripts.DI.Container;
using Asteroids.Scripts.DI.Unity.Extensions;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Factories.Views
{
	public class ViewFactory : IViewFactory
	{
		private readonly IAssetProvider _assetProvider;
		private readonly IContainer _container;
		private readonly Dictionary<string, IPool> _pools = new();

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
				if (_pools.TryGetValue(prefabKey, out IPool pool) == false)
				{
					pool = new SimplePool(() => CreateInstance(prefab).GetComponent<PoolableObject>());
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