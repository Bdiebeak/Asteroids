namespace Asteroids.Scripts.Core.UI.Base
{
	public interface IScreenService
	{
		void Show<TScreen>() where TScreen : IScreen;
		void CloseActive();
	}
}