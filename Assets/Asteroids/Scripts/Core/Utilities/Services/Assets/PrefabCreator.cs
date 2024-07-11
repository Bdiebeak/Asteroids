using Asteroids.Scripts.DI.Container;
using Asteroids.Scripts.DI.Unity.Extensions;
using UnityEngine;

namespace Asteroids.Scripts.Core.Utilities.Services.Assets
{
	public class PrefabCreator : IPrefabCreator
	{
		private readonly IContainer _container;
		private readonly IAssetProvider _assetProvider;

		public PrefabCreator(IContainer container, IAssetProvider assetProvider)
		{
			_assetProvider = assetProvider;
			_container = container;
		}

		public GameObject Instantiate(string assetKey, Transform parent = null)
		{
			GameObject prefab = _assetProvider.Load<GameObject>(assetKey);
			return _container.InstantiatePrefab(prefab, parent);
		}

		public GameObject Instantiate(string assetKey, Vector2 position, Transform parent = null)
		{
			GameObject prefab = _assetProvider.Load<GameObject>(assetKey);
			return _container.InstantiatePrefab(prefab, position, Quaternion.identity);
		}

		public GameObject Instantiate(string assetKey, Vector2 position, float rotation, Transform parent = null)
		{
			GameObject prefab = _assetProvider.Load<GameObject>(assetKey);
			return _container.InstantiatePrefab(prefab, position, Quaternion.Euler(0, 0, rotation));
		}
	}
}