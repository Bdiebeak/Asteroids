using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;

namespace Asteroids.Scripts.Core.Game.Features.Weapons.Requests
{
	public class ShootRequest : IRequest
	{
		public Entity shooter;
		public Entity weapon;
	}
}