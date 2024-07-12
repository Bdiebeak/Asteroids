using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Requests
{
	public class LaserShootRequest : IRequest
	{
		public Entity shooter;
		public Entity weapon;
	}
}