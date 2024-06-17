using UnityEngine;

namespace Asteroids.Scripts.Core.UI.Base
{
	public interface IUIFactory
	{
		Canvas GetMainCanvas();
		TScreen CreateScreen<TScreen>() where TScreen : IScreen;
	}
}