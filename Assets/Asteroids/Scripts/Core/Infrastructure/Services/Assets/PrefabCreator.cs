using Asteroids.Scripts.DI.Extensions;
using Asteroids.Scripts.DI.Resolver;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Services.Assets
{
	public class PrefabCreator : IPrefabCreator
	{
		private readonly IContainerResolver _containerResolver;
		private readonly IAssetProvider _assetProvider;

		public PrefabCreator(IContainerResolver containerResolver, IAssetProvider assetProvider)
		{
			_assetProvider = assetProvider;
			_containerResolver = containerResolver;
		}

		public GameObject Instantiate(string assetKey, Transform parent = null)
		{
			GameObject asset = _assetProvider.Load<GameObject>(assetKey);
			GameObject instance = Object.Instantiate(asset, parent);
			_containerResolver.InjectGameObject(instance);
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