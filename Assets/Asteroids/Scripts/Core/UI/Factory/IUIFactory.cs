using Asteroids.Scripts.Core.Infrastructure.Services.Screens;

namespace Asteroids.Scripts.Core.UI.Factory
{
	public interface IUIFactory
	{
		TScreen CreateScreen<TScreen>() where TScreen : IScreen;
	}
}