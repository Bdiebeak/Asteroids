using Asteroids.Scripts.Core.Gameplay.View;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Services
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