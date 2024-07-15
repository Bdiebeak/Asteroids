using Asteroids.Scripts.ECS.Requests;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Requests
{
	public class TeleportRequest : IRequest
	{
		public int targetEntityId;
		public Vector2 position;
	}
}