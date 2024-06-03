using Asteroids.Scripts.Logic.Infrastructure.Services;
using Asteroids.Scripts.Logic.View;
using Asteroids.Scripts.Unity.View;
using UnityEngine;

namespace Asteroids.Scripts.Unity.Infrastructure.Services
{
	[CreateAssetMenu(menuName = "SO/" + nameof(ViewFactory), fileName = nameof(ViewFactory))]
	public class ViewFactory : ScriptableObject, IViewFactory
	{
		// TODO: asset provider
		public UnityView playerView;

		public IView CreatePlayerView()
		{
			return Instantiate(playerView);
		}
	}
}