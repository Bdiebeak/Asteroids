using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Requests
{
	public class TeleportRequest : IRequest
	{
		public Entity target;
		public Vector2 position;
	}
}