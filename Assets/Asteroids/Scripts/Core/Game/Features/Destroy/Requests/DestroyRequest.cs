using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;

namespace Asteroids.Scripts.Core.Game.Features.Destroy.Requests
{
	public class DestroyRequest : IRequest
	{
		public Entity target;
	}
}