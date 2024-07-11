using Asteroids.Scripts.Core.Game.Behaviours;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Factories
{
	public interface IViewFactory
	{
		EntityView CreateView(string assetKey, Vector3 position, float rotation = 0);
	}
}