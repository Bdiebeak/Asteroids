using Asteroids.Scripts.ECS.Events;

namespace Asteroids.Scripts.Core.Game.Features.Collision.Events
{
	public class CollisionEnterEvent : IEvent
	{
		public int senderEntityId;
		public int collisionEntityId;
	}
}