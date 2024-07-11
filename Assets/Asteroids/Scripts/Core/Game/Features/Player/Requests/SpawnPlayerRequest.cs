using Asteroids.Scripts.ECS.Requests;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Player.Requests
{
	public class SpawnPlayerRequest : IRequest
	{
		public Vector2 position;
	}
}