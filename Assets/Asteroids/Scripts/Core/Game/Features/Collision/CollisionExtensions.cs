using Asteroids.Scripts.Core.Game.Features.Collision.Events;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Features.Collision
{
	public static class CollisionExtensions
	{
		public static bool TryGetEntities(this CollisionEnterEvent collisionEvent, IContext context,
										  out Entity sender, out Entity collision)
		{
			if (context.TryGetEntity(collisionEvent.senderEntityId, out sender) &&
				context.TryGetEntity(collisionEvent.collisionEntityId, out collision))
			{
				return true;
			}

			sender = default;
			collision = default;
			return false;
		}
	}
}