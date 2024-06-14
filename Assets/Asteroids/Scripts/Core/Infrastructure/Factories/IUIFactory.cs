using Asteroids.Scripts.Core.UI.Base;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Factories
{
	public interface IUIFactory
	{
		Canvas GetMainCanvas();
		TScreen CreateScreen<TScreen>() where TScreen : IScreen;
	}
}