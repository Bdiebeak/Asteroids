using Asteroids.Scripts.Core.Game.Features.Requests;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Features.Collision.Requests
{
	/// <summary>
	/// This request will be verified for the existence of colliding entities.
	/// </summary>
	public class ProvideCollisionEnterRequest : IRequest
	{
		public Entity sender;
		public Entity collision;
	}
}