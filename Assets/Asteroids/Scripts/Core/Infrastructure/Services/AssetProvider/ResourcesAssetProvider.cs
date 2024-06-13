using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Services.AssetProvider
{
	public class ResourcesAssetProvider : IAssetProvider
	{
		public TAsset Load<TAsset>(string key) where TAsset : class
		{
			Resources.LoadAsync(key, typeof(TAsset));
			return Resources.Load(key) as TAsset;
		}
	}
}