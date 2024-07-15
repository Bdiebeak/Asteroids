using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;

namespace Asteroids.Scripts.Core.Game.Features.Destroy.Requests
{
	public class DestroyWithTimerRequest : IRequest
	{
		public Entity target;
		public float timer;
	}
}