namespace Asteroids.Scripts.Core.Infrastructure.Services.Screens
{
	public interface IScreenService
	{
		void Show<TScreen>() where TScreen : IScreen;
		void CloseActive();
	}
}