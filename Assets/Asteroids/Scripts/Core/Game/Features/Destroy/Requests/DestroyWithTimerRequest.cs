using Asteroids.Scripts.ECS.Requests;

namespace Asteroids.Scripts.Core.Game.Features.Destroy.Requests
{
	public class DestroyWithTimerRequest : IRequest
	{
		public int targetEntityId;
		public float timer;
	}
}