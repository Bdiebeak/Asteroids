using Asteroids.Scripts.Core.Game.Features.Requests;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Requests
{
	public class SpawnAsteroidPiecesRequest : IRequest
	{
		public Vector2 position;
		public int count;
	}
}