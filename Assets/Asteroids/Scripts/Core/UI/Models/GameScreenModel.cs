using UnityEngine;

namespace Asteroids.Scripts.Core.UI.Models
{
	public class GameScreenModel
	{
		public int score;
		public Vector2 position;
		public float rotation;
		public Vector2 velocity;
		public float velocityMagnitude;
		public float currentLaserCount;
		public float maxLaserCount;
		public float laserCooldown;
	}
}