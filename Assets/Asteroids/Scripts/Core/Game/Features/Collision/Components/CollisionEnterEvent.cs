using Asteroids.Scripts.Core.Game.Features.Events;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Features.Collision.Components
{
	/// <summary>
	/// This event will be triggered when all entities exist.
	/// </summary>
	public class CollisionEnterEvent : IEvent
	{
		public Entity sender;
		public Entity collision;
	}
}