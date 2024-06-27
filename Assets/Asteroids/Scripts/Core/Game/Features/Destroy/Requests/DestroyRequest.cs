using Asteroids.Scripts.Core.Game.Features.Requests;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Features.Destroy.Requests
{
	public class DestroyRequest : IRequest
	{
		public Entity target;
	}
}