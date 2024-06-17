using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Services.Assets
{
	public class ResourcesAssetProvider : IAssetProvider
	{
		private readonly Dictionary<string, object> _cachedAssets = new();

		public TAsset Load<TAsset>(string path) where TAsset : class
		{
			if (_cachedAssets.TryGetValue(path, out object asset) == false)
			{
				asset = Resources.Load(path);
				_cachedAssets.Add(path, asset);
			}
			return (TAsset)asset;
		}
	}
}