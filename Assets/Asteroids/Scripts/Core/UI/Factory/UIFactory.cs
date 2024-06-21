using System;
using System.Collections.Generic;
using Asteroids.Scripts.Core.Infrastructure.Services.Assets;
using Asteroids.Scripts.Core.Infrastructure.Services.Screens;
using Asteroids.Scripts.Core.UI.Screens;
using UnityEngine;

namespace Asteroids.Scripts.Core.UI.Factory
{
	public class UIFactory : IUIFactory
	{
		private Canvas _canvas;
		private readonly IPrefabCreator _prefabCreator;
		private readonly Dictionary<Type, string> _screenKeys;

		public UIFactory(IPrefabCreator prefabCreator)
		{
			_prefabCreator = prefabCreator;
			// We can get rid of it via Addressables and Labels.
			// This keys will be filled automatically.
			_screenKeys = new Dictionary<Type, string>()
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
			return _prefabCreator.InstantiateComponent<TScreen>(_screenKeys[screenType], canvas.transform);
		}

		private Canvas GetOrCreateMainCanvas()
		{
			if (_canvas == null)
			{
				_canvas = _prefabCreator.InstantiateComponent<Canvas>(UIAssetKeys.MainCanvas);
			}
			return _canvas;
		}
	}
}