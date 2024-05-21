using System;
using System.Numerics;

namespace Asteroids.Scripts.Logic.Infrastructure.Utilities
{
	public static class MathHelper
	{
		public const float Deg2Rad = (float)(Math.PI / 180f);

		public static Vector2 Rotate(this Vector2 vector, float angle)
		{
			float angleInRadians = angle * Deg2Rad;
			float cosAngle = (float)Math.Cos(angleInRadians);
			float sinAngle = (float)Math.Sin(angleInRadians);
			return new Vector2(cosAngle * vector.X - sinAngle * vector.Y,
							   sinAngle * vector.X + cosAngle * vector.Y);
		}
	}
}