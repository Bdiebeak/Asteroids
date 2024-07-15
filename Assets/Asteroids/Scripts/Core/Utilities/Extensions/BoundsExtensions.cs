using UnityEngine;

namespace Asteroids.Scripts.Core.Utilities.Extensions
{
	public static class BoundsExtensions
	{
		public static Vector2 GetRandomEdgePosition(this Bounds bounds)
		{
			bool isVerticalEdge = Random.value >= 0.5f;
			bool isPositiveSide = Random.value >= 0.5f;

			if (isVerticalEdge)
			{
				// Get edge position on top or bottom side.
				float x = Random.Range(bounds.min.x, bounds.max.x);
				float y = isPositiveSide ? bounds.max.y : bounds.min.y;
				return new Vector2(x, y);
			}
			else
			{
				// Get edge position on left or right side.
				float x = isPositiveSide ? bounds.max.x : bounds.min.x;
				float y = Random.Range(bounds.min.y, bounds.max.y);
				return new Vector2(x, y);
			}
		}

		public static bool IsInBounds(this Bounds bounds, Vector2 position)
		{
			// We should use same Z coordinate, because Bounds.Contains works with a 3d space.
			Vector3 worldPosition = new(position.x, position.y, bounds.center.z);
			return bounds.Contains(worldPosition);
		}

		public static Vector2 GetOppositeEdgePosition(this Bounds bound, Vector2 position)
		{
			if (position.x < bound.min.x)
			{
				position.x = bound.max.x;
			}
			else if (position.x > bound.max.x)
			{
				position.x = bound.min.x;
			}

			if (position.y < bound.min.y)
			{
				position.y = bound.max.y;
			}
			else if (position.y > bound.max.y)
			{
				position.y = bound.min.y;
			}
			return position;
		}
	}
}