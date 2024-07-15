using Asteroids.Scripts.ECS.Requests;

namespace Asteroids.Scripts.Core.Game.Features.Weapons.Requests
{
	public class ShootRequest : IRequest
	{
		public int weaponEntityId;
	}
}