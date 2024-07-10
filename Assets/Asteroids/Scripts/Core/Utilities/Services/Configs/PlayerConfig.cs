using UnityEngine;

namespace Asteroids.Scripts.Core.Utilities.Services.Configs
{
	public static class PlayerConfig
	{
		public const float RotationSpeed = 200f;
		public const float Acceleration = 9f;
		public const float Deceleration = 1.25f;
		public const float MoveSpeed = 8.5f;
		public static readonly Vector2 SpawnPosition = Vector2.zero;
	}
}