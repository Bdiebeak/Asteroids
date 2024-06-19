using Asteroids.Scripts.Core.Infrastructure.Services.Screens;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Factories
{
	public interface IUIFactory
	{
		Canvas CreateMainCanvas();
		TScreen CreateScreen<TScreen>() where TScreen : IScreen;
	}
}