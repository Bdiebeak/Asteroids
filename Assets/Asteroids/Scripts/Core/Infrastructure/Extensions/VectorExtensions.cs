using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Extensions
{
	public static class VectorExtensions
	{
		public static Vector2 Rotate(this Vector2 vector, float angle)
		{
			float angleInRadians = angle * Mathf.Deg2Rad;
			float cosAngle = Mathf.Cos(angleInRadians);
			float sinAngle = Mathf.Sin(angleInRadians);
			return new Vector2(cosAngle * vector.x - sinAngle * vector.y,
							   sinAngle * vector.x + cosAngle * vector.y);
		}
	}
}