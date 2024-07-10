using Asteroids.Scripts.Core.Game.Requests;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Requests
{
	public class TeleportRequest : IRequest
	{
		public Entity target;
		public Vector2 position;
	}
}