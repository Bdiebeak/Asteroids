using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.ECS.Systems
{
	public abstract class Feature
	{
		public abstract void AddTo(SystemsContainer systems);
	}
}