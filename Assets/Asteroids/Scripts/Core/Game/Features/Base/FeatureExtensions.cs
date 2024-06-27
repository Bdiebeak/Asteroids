using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Base
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