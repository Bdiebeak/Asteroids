using System;
using System.Collections.Generic;
using Asteroids.Scripts.Core.UI.Screens;
using Asteroids.Scripts.Core.Utilities.Services.Assets;
using Asteroids.Scripts.DI.Container;
using Asteroids.Scripts.DI.Unity.Extensions;
using UnityEngine;

namespace Asteroids.Scripts.Core.UI.Factory
{
	public class UIFactory : IUIFactory
	{
		private Canvas _canvas;
		private readonly IContainer _container;
		private readonly IAssetProvider _assetProvider;
		private readonly Dictionary<Type, string> _screenKeys;

		public UIFactory(IContainer container, IAssetProvider assetProvider)
		{
			_container = container;
			_assetProvider = assetProvider;

			// Don't like this part, but can get rid of it via Addressables and Labels.
			// This keys will be filled automatically.
			_screenKeys = new Dictionary<Type, string>
			{
				{typeof(GameStartScreen), UIAssetKeys.StartScreen},
				{typeof(GameScreen), UIAssetKeys.GameScreen},
				{typeof(GameOverScreen), UIAssetKeys.GameOverScreen}
			};
		}

		public TScreen CreateScreen<TScreen>() where TScreen : IScreen
		{
			Type screenType = typeof(TScreen);
			Canvas canvas = GetOrCreateMainCanvas();
			return Instantiate(_screenKeys[screenType], canvas.transform).GetComponent<TScreen>();
		}

		private Canvas GetOrCreateMainCanvas()
		{
			if (_canvas == null)
			{
				_canvas = Instantiate(UIAssetKeys.MainCanvas).GetComponent<Canvas>();
			}
			return _canvas;
		}

		private GameObject Instantiate(string assetKey, Transform parent = null)
		{
			GameObject prefab = _assetProvider.Load<GameObject>(assetKey);
			return _container.InstantiatePrefab(prefab, parent);
		}
	}
}