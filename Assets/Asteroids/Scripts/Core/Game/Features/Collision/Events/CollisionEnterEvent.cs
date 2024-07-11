using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Events;

namespace Asteroids.Scripts.Core.Game.Features.Collision.Events
{
	/// <summary>
	/// If this event was triggered, it means that the entities within it can be handled correctly,
	/// without worrying that they are inactive.
	/// </summary>
	public class CollisionEnterEvent : IEvent
	{
		public Entity sender;
		public Entity collision;
	}
}