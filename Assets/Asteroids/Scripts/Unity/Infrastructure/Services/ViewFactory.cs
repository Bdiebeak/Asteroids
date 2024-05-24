using Asteroids.Scripts.Logic.Infrastructure.Services;
using Asteroids.Scripts.Logic.View;
using Asteroids.Scripts.Unity.View;
using UnityEngine;

namespace Asteroids.Scripts.Unity.Infrastructure.Services
{
	public class ViewFactory : MonoBehaviour, IViewFactory
	{
		// TODO: asset provider
		public UnityView playerView;

		public IView CreatePlayerView()
		{
			return Instantiate(playerView);
		}
	}
}