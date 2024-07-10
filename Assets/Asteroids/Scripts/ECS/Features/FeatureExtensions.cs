using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.ECS.Features
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