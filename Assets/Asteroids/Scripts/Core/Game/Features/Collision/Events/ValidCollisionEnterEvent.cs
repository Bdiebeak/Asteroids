using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Events;

namespace Asteroids.Scripts.Core.Game.Features.Collision.Events
{
	/// <summary>
	/// If this event is triggered, it means that the entities involved have already been validated
	/// and can be handled correctly without worrying about their inactivity.
	/// This event is only created after all necessary validations, which is why it has Valid in name.
	/// </summary>
	public class ValidCollisionEnterEvent : IEvent
	{
		public Entity sender;
		public Entity collision;
	}
}