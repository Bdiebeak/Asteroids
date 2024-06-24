using Asteroids.Scripts.Core.Game.Features.Base;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Utilities.Extensions
{
	public static class FeatureExtensions
	{
		public static SystemsContainer Add(this SystemsContainer container, Feature feature)
		{
			feature.AddTo(container);
			return container;
		}
	}
}