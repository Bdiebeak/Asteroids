using UnityEngine;

namespace Asteroids.Scripts.Core.UI.Models
{
	public class GameScreenModel
	{
		public int Score;
		public Vector2 Position;
		public float Rotation;
		public Vector2 Velocity;
		public float VelocityMagnitude;
		public float CurrentLaserCount;
		public float MaxLaserCount;
		public float LaserCooldown;
	}
}