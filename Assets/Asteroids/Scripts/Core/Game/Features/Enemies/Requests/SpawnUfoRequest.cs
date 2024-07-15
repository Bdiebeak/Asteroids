using Asteroids.Scripts.ECS.Requests;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Requests
{
	public class SpawnUfoRequest : IRequest
	{
		public Vector2 position;
	}
}