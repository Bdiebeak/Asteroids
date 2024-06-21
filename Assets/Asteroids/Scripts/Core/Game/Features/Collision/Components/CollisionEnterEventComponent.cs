using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Features.Collision.Components
{
	public class CollisionEnterEventComponent : IComponent
	{
		public Entity sender;
		public Entity collision;
	}
}