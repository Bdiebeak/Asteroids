using UnityEngine;

namespace Asteroids.Scripts.Core.Utilities.Extensions
{
	public static class BoundsExtensions
	{
		public static Vector2 GetRandomEdgePosition(this Bounds bounds)
		{
			bool isVerticalEdge = Random.value >= 0.5f;
			bool isPositiveSide = Random.value >= 0.5f;

			Vector2 position = Vector2.zero;
			if (isVerticalEdge)
			{
				// Spawn on top or bottom side.
				position.x = Random.Range(bounds.min.x, bounds.max.x);
				position.y = isPositiveSide ? bounds.max.y : bounds.min.y;
			}
			else
			{
				// Spawn on left or right side.
				position.x = isPositiveSide ? bounds.max.x : bounds.min.x;
				position.y = Random.Range(bounds.min.y, bounds.max.y);
			}
			return position;
		}

		public static bool IsInBounds(this Bounds bounds, Vector2 position)
		{
			// We should use same Z coordinate, because Bounds.Contains works with a 3d space.
			Vector3 worldPosition = new(position.x, position.y, bounds.center.z);
			return bounds.Contains(worldPosition);
		}
	}
}