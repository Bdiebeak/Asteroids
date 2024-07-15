using UnityEngine;

namespace Asteroids.Scripts.Core.UI.Models
{
	public class GameScreenModel : IScreenModel
	{
		public int score;
		public Vector2 position;
		public float rotation;
		public Vector2 velocity;
		public float velocityMagnitude;
		public float currentLaserCount;
		public float maxLaserCount;
		public float laserCooldown;

		public void Reset()
		{
			score = 0;
			position = Vector2.zero;
			rotation = 0;
			velocity = Vector2.zero;
			velocityMagnitude = 0;
			currentLaserCount = 0;
			maxLaserCount = 0;
			laserCooldown = 0;
		}
	}
}