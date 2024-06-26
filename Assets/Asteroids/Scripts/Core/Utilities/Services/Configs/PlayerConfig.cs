using UnityEngine;

namespace Asteroids.Scripts.Core.Utilities.Services.Configs
{
	public static class PlayerConfig
	{
		public static float shipAngularSpeed = 200f;
		public static float shipAcceleration = 9f;
		public static float shipDrag = 1.25f;
		public static float shipMaxSpeed = 8.5f;

		public static float bulletCooldown = 0.25f;
		public static float bulletSpeed = 12.5f;
		public static float laserCooldown = 10;
		public static int maxLaserCharges = 2;

		public static Vector2 spawnPosition = Vector2.zero;
	}
}