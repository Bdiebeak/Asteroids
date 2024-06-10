using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Services.AssetProvider
{
	public class ResourcesAssetProvider : IAssetProvider
	{
		public TAsset Load<TAsset>(string key) where TAsset : class
		{
			return Resources.Load(key) as TAsset;
		}
	}
}