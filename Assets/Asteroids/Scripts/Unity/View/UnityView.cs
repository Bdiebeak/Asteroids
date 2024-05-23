using Asteroids.Scripts.Logic.View;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Asteroids.Scripts.Unity.View
{
	public class UnityView : MonoBehaviour, IView
	{
		public void SetPosition(Vector2 position)
		{
			Vector3 currentPosition = transform.position;
			Vector3 newPosition = new(position.X, position.Y, currentPosition.z);
			transform.position = newPosition;
		}

		public void SetRotation(float angle)
		{
			Vector3 currentRotation = transform.rotation.eulerAngles;
			Quaternion newRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, angle);
			transform.rotation = newRotation;
		}

		public void Destroy()
		{
			Destroy(gameObject);
		}
	}
}