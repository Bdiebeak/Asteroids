using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;

namespace Asteroids.Scripts.Core.Game.Features.Collision.Requests
{
	/// <summary>
	/// This is an intermediate event for <see cref="CollisionProvider"/> and ECS communication.
	/// It will be verified for the existence of colliding entities and converted into event.
	/// </summary>
	public class CollisionEnterRequest : IRequest
	{
		public Entity sender;
		public Entity collision;
	}
}