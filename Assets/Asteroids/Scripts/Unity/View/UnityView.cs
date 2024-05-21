using Asteroids.Scripts.Logic.View;
using UnityEngine;

namespace Asteroids.Scripts.Unity.View
{
	public class UnityView : MonoBehaviour, IView
	{
		public void SetPosition(float x, float y)
		{
			Vector3 currentPosition = transform.position;
			Vector3 newPosition = new(x, y, currentPosition.z);
			transform.position = newPosition;
		}

		public void SetRotation(float angle)
		{
			Vector3 currentRotation = transform.rotation.eulerAngles;
			Quaternion newRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, angle);
			transform.rotation = newRotation;
		}
	}
}