using Asteroids.Scripts.Core.Gameplay.View;

namespace Asteroids.Scripts.Core.Infrastructure.Factories
{
	public interface IViewFactory
	{
		IView CreatePlayerView();
	}
}