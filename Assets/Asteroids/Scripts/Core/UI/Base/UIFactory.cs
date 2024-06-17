using System;
using System.Collections.Generic;
using Asteroids.Scripts.Core.Infrastructure.Constants;
using Asteroids.Scripts.Core.Infrastructure.Services.AssetProvider;
using Asteroids.Scripts.Core.UI.Screens;
using Asteroids.Scripts.DI.Resolver;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.Scripts.Core.UI.Base
{
	public class UIFactory : IUIFactory
	{
		private Canvas _canvas;
		private readonly Dictionary<Type, string> _screenKeys;
		private readonly IContainerResolver _containerResolver;
		private readonly IAssetProvider _assetProvider;

		public UIFactory(IContainerResolver containerResolver, IAssetProvider assetProvider)
		{
			_containerResolver = containerResolver;
			_assetProvider = assetProvider;
			_screenKeys = new Dictionary<Type, string>()
			{
				{typeof(GameStartScreen), AssetKeys.StartScreen},
				{typeof(GameScreen), AssetKeys.GameScreen},
				{typeof(GameOverScreen), AssetKeys.GameOverScreen}
			};
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

		public TScreen CreateScreen<TScreen>() where TScreen : IScreen
		{
			Type screenType = typeof(TScreen);
			GameObject screenAsset = _assetProvider.Load<GameObject>(_screenKeys[screenType]);
			TScreen screen = Object.Instantiate(screenAsset, GetMainCanvas().transform).GetComponent<TScreen>();
			_containerResolver.InjectInto(screen);
			return screen;
		}
	}
}