using System;
using System.Collections.Generic;
using Asteroids.Scripts.Core.Infrastructure.Factories;
using Asteroids.Scripts.Core.Infrastructure.Services.AssetProvider;

namespace Asteroids.Scripts.Core.UI.Base
{
	public class ScreenService : IScreenService
	{
		private readonly Dictionary<Type, IScreen> _screens = new();
		private readonly IUIFactory _uiFactory;
		private IScreen _activeScreen;
		private bool HasActiveScreen => _activeScreen != null;

		public ScreenService(IUIFactory uiFactory)
		{
			_uiFactory = uiFactory;
		}

		public void Show<TScreen>() where TScreen : IScreen
		{
			Type screenType = typeof(TScreen);
			if (_screens.TryGetValue(screenType, out IScreen screen) == false)
			{
				screen = _uiFactory.CreateScreen<TScreen>();
				_screens.Add(screenType, screen);
			}
			CloseActive();
			screen.Show();
			_activeScreen = screen;
		}

		public void CloseActive()
		{
			if (HasActiveScreen == false)
			{
				return;
			}
			_activeScreen.Close();
		}
	}
}