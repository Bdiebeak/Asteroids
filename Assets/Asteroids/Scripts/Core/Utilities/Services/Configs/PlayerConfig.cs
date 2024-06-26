using UnityEngine;

namespace Asteroids.Scripts.Core.Utilities.Services.Configs
{
	public static class PlayerConfig
	{
		public static float shipAngularSpeed = 200f;
		public static float shipAcceleration = 9f;
		public static float shipDrag = 1.25f;
		public static float shipMaxSpeed = 8.5f;
		public static Vector2 spawnPosition = Vector2.zero;
	}
}