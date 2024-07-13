using UnityEngine;

namespace Asteroids.Scripts.Core.Utilities.Services.Configs
{
	public class PlayerConfig
	{
		public float MoveSpeed = 8.5f;
		public float MoveAcceleration = 9f;
		public float MoveDeceleration = 1.25f;
		public float RotationSpeed = 200f;
		public Vector2 SpawnPoint = Vector2.zero;
	}
}