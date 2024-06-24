using System;
using System.Collections.Generic;
using Asteroids.Scripts.Core.UI.Factory;
using Asteroids.Scripts.Core.UI.Screens;

namespace Asteroids.Scripts.Core.Utilities.Services.Screens
{
	public class ScreenService : IScreenService
	{
		private IScreen _activeScreen;
		private readonly IUIFactory _uiFactory;
		private readonly Dictionary<Type, IScreen> _screens = new();

		private bool HasActiveScreen => _activeScreen != null;

		public ScreenService(IUIFactory uiFactory)
		{
			_uiFactory = uiFactory;
		}

		public void Show<TScreen>() where TScreen : IScreen
		{
			CloseActive();

			Type requiredType = typeof(TScreen);
			if (_screens.TryGetValue(requiredType, out IScreen screen) == false)
			{
				screen = _uiFactory.CreateScreen<TScreen>();
				_screens.Add(requiredType, screen);
			}
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