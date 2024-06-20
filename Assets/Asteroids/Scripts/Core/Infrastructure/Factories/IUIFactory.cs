using Asteroids.Scripts.Core.Infrastructure.Services.Screens;

namespace Asteroids.Scripts.Core.Infrastructure.Factories
{
	public interface IUIFactory
	{
		TScreen CreateScreen<TScreen>() where TScreen : IScreen;
	}
}