using UnityEngine;

namespace Asteroids.Scripts.Core.Utilities.Services.Configs
{
	public static class PlayerConfig
	{
		public static float shipAngularSpeed = 200f;
		public static float shipAcceleration = 9f;
		public static float shipDrag = 1.25f;
		public static float shipMaxSpeed = 8.5f;

		public static float bulletCooldown = 1;
		public static float laserCooldown = 5;
		public static int maxLaserCharges = 2;
		public static float bulletSpeed = 15;

		public static Vector2 spawnPosition = Vector2.zero;
	}
}