using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Services.AssetProvider
{
	public class ResourcesAssetProvider : IAssetProvider
	{
		private readonly Dictionary<string, object> _cachedAssets = new();

		public TAsset Load<TAsset>(string key) where TAsset : class
		{
			if (_cachedAssets.TryGetValue(key, out object asset) == false)
			{
				asset = Resources.Load(key);
				_cachedAssets.Add(key, asset);
			}
			return (TAsset)asset;
		}
	}
}