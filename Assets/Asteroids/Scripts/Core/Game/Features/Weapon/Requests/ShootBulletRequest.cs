using Asteroids.Scripts.Core.Game.Requests;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Requests
{
	public class ShootBulletRequest : IRequest
	{
		public Entity shooter;
		public Vector2 position;
		public Vector2 direction;
	}
}