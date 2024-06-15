using System;
using System.Collections.Generic;
using Asteroids.Scripts.Core.UI.Screens;

namespace Asteroids.Scripts.Core.UI.Base
{
	public class ScreenService : IScreenService
	{
		private IScreen _activeScreen;
		private readonly Dictionary<Type, IScreen> _screens = new();
		private readonly IUIFactory _uiFactory;

		private bool HasActiveScreen => _activeScreen != null;

		public ScreenService(IUIFactory uiFactory)
		{
			_uiFactory = uiFactory;
		}

		// TODO: refactoring. It isn't scalable at all.
		public void ShowStartScreen()
		{
			CloseActive();
			if (TryGetScreen(out StartScreen screen) == false)
			{
				screen = _uiFactory.CreateStartScreen();
				_screens.Add(typeof(StartScreen), screen);
			}
			screen.Show();
			_activeScreen = screen;
		}

		public void ShowGameScreen()
		{
			CloseActive();
			if (TryGetScreen(out GameScreen screen) == false)
			{
				screen = _uiFactory.CreateGameScreen();
				_screens.Add(typeof(GameScreen), screen);
			}
			screen.Show();
			_activeScreen = screen;
		}

		public void ShowGameOverScreen()
		{
			CloseActive();
			if (TryGetScreen(out GameOverScreen screen) == false)
			{
				screen = _uiFactory.CreateGameOverScreen();
				_screens.Add(typeof(GameOverScreen), screen);
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

		private bool TryGetScreen<TScreen>(out TScreen screen) where TScreen : IScreen
		{
			Type requiredType = typeof(TScreen);
			if (_screens.TryGetValue(requiredType, out IScreen cachedScreen))
			{
				screen = (TScreen)cachedScreen;
				return true;
			}
			screen = default;
			return false;
		}
	}
}