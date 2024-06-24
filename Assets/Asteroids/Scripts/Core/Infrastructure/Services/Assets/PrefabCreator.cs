using Asteroids.Scripts.DI;
using Asteroids.Scripts.DI.Extensions;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Services.Assets
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
			GameObject asset = _assetProvider.Load<GameObject>(assetKey);
			GameObject instance = Object.Instantiate(asset, parent);
			_container.InjectGameObject(instance);
			return instance;
		}

		public TComponent InstantiateComponent<TComponent>(string assetKey, Transform parent = null)
		{
			GameObject instance = Instantiate(assetKey, parent);
			TComponent component = instance.GetComponent<TComponent>();
			return component;
		}
	}
}