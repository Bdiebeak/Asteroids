using UnityEngine;

namespace Asteroids.Scripts.Core.Utilities.Services.Configs
{
	public class PlayerConfig
	{
		public float moveSpeed = 8.5f;
		public float moveAcceleration = 9f;
		public float moveDeceleration = 1.25f;
		public float rotationSpeed = 200f;
		public Vector2 spawnPoint = Vector2.zero;
	}
}