using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Gameplay.Collisions.Components
{
	public class CollisionEnterEventComponent : IComponent
	{
		public Entity sender;
		public Entity collision;
	}
}