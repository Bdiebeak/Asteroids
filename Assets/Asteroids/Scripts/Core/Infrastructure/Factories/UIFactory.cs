using System;
using System.Collections.Generic;
using Asteroids.Scripts.Core.Infrastructure.Constants;
using Asteroids.Scripts.Core.Infrastructure.Services.Assets;
using Asteroids.Scripts.Core.Infrastructure.Services.Screens;
using Asteroids.Scripts.Core.UI.Screens;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Factories
{
	public class UIFactory : IUIFactory
	{
		private Canvas _canvas;
		private readonly Dictionary<Type, string> _screenKeys;
		private readonly IPrefabCreator _prefabCreator;

		public UIFactory(IPrefabCreator prefabCreator)
		{
			_prefabCreator = prefabCreator;
			_screenKeys = new Dictionary<Type, string>()
			{
				{typeof(GameStartScreen), AssetKeys.StartScreen},
				{typeof(GameScreen), AssetKeys.GameScreen},
				{typeof(GameOverScreen), AssetKeys.GameOverScreen}
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
				_canvas = _prefabCreator.InstantiateComponent<Canvas>(AssetKeys.MainCanvas);
			}
			return _canvas;
		}
	}
}