using UnityEngine;

namespace Asteroids.Scripts.Core.Utilities.Services.GameCamera
{
	public class CameraService : ICameraService
	{
		public Camera MainCamera { get; private set; }
		public Bounds Bounds { get; private set; }

		public void Initialize(Camera mainCamera)
		{
			MainCamera = mainCamera;
			Bounds = CalculateBounds();
		}

		private Bounds CalculateBounds()
		{
			float screenAspect = (float)Screen.width / Screen.height;
			float cameraHeight = MainCamera.orthographicSize * 2;
			Vector2 boundsSize = new(cameraHeight * screenAspect, cameraHeight);
			return new Bounds(MainCamera.transform.position, boundsSize);
		}
	}
}