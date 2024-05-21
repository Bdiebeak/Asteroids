using Asteroids.Scripts.Logic.View;

namespace Asteroids.Scripts.Logic.Infrastructure.Services
{
	public interface IViewFactory
	{
		IView CreatePlayerView();
	}
}