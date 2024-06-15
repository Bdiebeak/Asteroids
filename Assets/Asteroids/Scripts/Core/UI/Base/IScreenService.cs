namespace Asteroids.Scripts.Core.UI.Base
{
	public interface IScreenService
	{
		void ShowStartScreen();
		void ShowGameScreen();
		void ShowGameOverScreen();
		void CloseActive();
	}
}