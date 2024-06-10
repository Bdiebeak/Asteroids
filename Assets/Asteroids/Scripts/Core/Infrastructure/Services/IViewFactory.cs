using Asteroids.Scripts.Core.Gameplay.View;

namespace Asteroids.Scripts.Core.Infrastructure.Services
{
	public interface IViewFactory
	{
		IView CreatePlayerView();
	}
}