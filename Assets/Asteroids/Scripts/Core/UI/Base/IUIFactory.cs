using Asteroids.Scripts.Core.UI.Screens;
using UnityEngine;

namespace Asteroids.Scripts.Core.UI.Base
{
	public interface IUIFactory
	{
		Canvas GetMainCanvas();
		StartScreen CreateStartScreen();
		GameScreen CreateGameScreen();
		GameOverScreen CreateGameOverScreen();
	}
}