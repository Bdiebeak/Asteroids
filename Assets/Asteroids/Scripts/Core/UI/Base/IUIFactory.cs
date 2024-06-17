using UnityEngine;

namespace Asteroids.Scripts.Core.UI.Base
{
	public interface IUIFactory
	{
		Canvas CreateMainCanvas();
		TScreen CreateScreen<TScreen>() where TScreen : IScreen;
	}
}