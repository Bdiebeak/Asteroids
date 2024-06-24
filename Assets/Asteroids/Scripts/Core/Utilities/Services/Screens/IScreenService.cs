using Asteroids.Scripts.Core.UI.Screens;

namespace Asteroids.Scripts.Core.Utilities.Services.Screens
{
	public interface IScreenService
	{
		void Show<TScreen>() where TScreen : IScreen;
		void CloseActive();
	}
}