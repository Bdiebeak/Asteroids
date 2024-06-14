using Asteroids.Scripts.Core.Gameplay.View;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Factories
{
	public interface IGameFactory
	{
		Camera CreateMainCamera();
		IView CreatePlayerView();
	}
}