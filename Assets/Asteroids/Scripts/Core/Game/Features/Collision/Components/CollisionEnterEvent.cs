using Asteroids.Scripts.Core.Game.Features.Events;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Features.Collision.Components
{
	public class CollisionEnterEvent : IEvent
	{
		public Entity sender;
		public Entity collision;
	}
}