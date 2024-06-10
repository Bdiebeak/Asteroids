using Asteroids.Scripts.Core.Gameplay.View;
using Asteroids.Scripts.Core.Infrastructure.Constants;
using Asteroids.Scripts.Core.Infrastructure.Services.AssetProvider;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Factories
{
	public class ViewFactory : IViewFactory
	{
		private readonly IAssetProvider _assetProvider;

		public ViewFactory(IAssetProvider assetProvider)
		{
			_assetProvider = assetProvider;
		}

		public IView CreatePlayerView()
		{
			GameObject playerAsset = _assetProvider.Load<GameObject>(AssetKeys.Player);
			return Object.Instantiate(playerAsset).GetComponent<IView>();
		}
	}
}