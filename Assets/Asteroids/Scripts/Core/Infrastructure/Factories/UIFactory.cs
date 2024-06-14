using Asteroids.Scripts.Core.Infrastructure.Constants;
using Asteroids.Scripts.Core.Infrastructure.Services.AssetProvider;
using Asteroids.Scripts.Core.UI.Base;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Factories
{
	public class UIFactory : IUIFactory
	{
		private Canvas _canvas;
		private IAssetProvider _assetProvider;

		public UIFactory(IAssetProvider assetProvider)
		{
			_assetProvider = assetProvider;
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
			// TODO: don't use naming.
			string screenName = typeof(TScreen).Name;
			GameObject screen = _assetProvider.Load<GameObject>($"{AssetKeys.ScreensFolder}/{screenName}");
			return Object.Instantiate(screen, GetMainCanvas().transform).GetComponent<TScreen>();
		}
	}
}