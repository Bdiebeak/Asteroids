using Asteroids.Scripts.Core.Infrastructure.Constants;
using Asteroids.Scripts.Core.Infrastructure.Services.AssetProvider;
using Asteroids.Scripts.Core.UI.Models;
using Asteroids.Scripts.Core.UI.Screens;
using UnityEngine;

namespace Asteroids.Scripts.Core.UI.Base
{
	public class UIFactory : IUIFactory
	{
		private Canvas _canvas;
		private readonly IAssetProvider _assetProvider;
		private readonly StartScreenModel _startScreenModel;
		private readonly GameScreenModel _gameScreenModel;
		private readonly GameOverScreenModel _gameOverScreenModel;

		public UIFactory(IAssetProvider assetProvider, StartScreenModel startScreenModel,
						 GameScreenModel gameScreenModel, GameOverScreenModel gameOverScreenModel)
		{
			_assetProvider = assetProvider;
			_startScreenModel = startScreenModel;
			_gameScreenModel = gameScreenModel;
			_gameOverScreenModel = gameOverScreenModel;
		}

		public Canvas GetMainCanvas()
		{
			if (_canvas == null)
			{
				GameObject canvas = _assetProvider.Load<GameObject>(AssetKeys.MainCanvas);
				_canvas = Object.Instantiate(canvas).GetComponent<Canvas>();
			}
			return _canvas;
		}

		// TODO: refactoring. It isn't scalable at all.
		public StartScreen CreateStartScreen()
		{
			GameObject screenAsset = _assetProvider.Load<GameObject>(AssetKeys.StartScreen);
			StartScreen screen = Object.Instantiate(screenAsset, GetMainCanvas().transform).GetComponent<StartScreen>();
			screen.Construct(_startScreenModel);
			return screen;
		}

		public GameScreen CreateGameScreen()
		{
			GameObject screenAsset = _assetProvider.Load<GameObject>(AssetKeys.GameScreen);
			GameScreen screen = Object.Instantiate(screenAsset, GetMainCanvas().transform).GetComponent<GameScreen>();
			screen.Construct(_gameScreenModel);
			return screen;
		}

		public GameOverScreen CreateGameOverScreen()
		{
			GameObject screenAsset = _assetProvider.Load<GameObject>(AssetKeys.GameOverScreen);
			GameOverScreen screen = Object.Instantiate(screenAsset, GetMainCanvas().transform).GetComponent<GameOverScreen>();
			screen.Construct(_gameOverScreenModel);
			return screen;
		}
	}
}