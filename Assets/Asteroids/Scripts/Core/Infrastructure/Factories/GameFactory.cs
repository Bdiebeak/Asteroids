using Asteroids.Scripts.Core.Gameplay.View;
using Asteroids.Scripts.Core.Infrastructure.Constants;
using Asteroids.Scripts.Core.Infrastructure.Services.AssetProvider;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Factories
{
	public class GameFactory : IGameFactory
	{
		private readonly IAssetProvider _assetProvider;

		public GameFactory(IAssetProvider assetProvider)
		{
			_assetProvider = assetProvider;
		}

		public Camera CreateMainCamera()
		{
			GameObject cameraAsset = _assetProvider.Load<GameObject>(AssetKeys.MainCamera);
			return Object.Instantiate(cameraAsset).GetComponent<Camera>();
		}

		public IView CreatePlayerView()
		{
			GameObject playerAsset = _assetProvider.Load<GameObject>(AssetKeys.Player);
			return Object.Instantiate(playerAsset).GetComponent<IView>();
		}
	}
}