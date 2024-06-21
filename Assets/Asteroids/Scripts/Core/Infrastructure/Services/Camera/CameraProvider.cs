using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Infrastructure.Services.Configs;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Services.Camera
{
	public class CameraProvider : ICameraProvider
	{
		public UnityEngine.Camera MainCamera { get; private set; }
		public Bounds Bounds { get; private set; }

		private readonly IGameFactory _gameFactory;

		public CameraProvider(IGameFactory gameFactory)
		{
			_gameFactory = gameFactory;
		}

		// TODO: Container IInitializable
		public void Initialize()
		{
			MainCamera = _gameFactory.CreateMainCamera();
			Bounds = CalculateBounds();
		}

		private Bounds CalculateBounds()
		{
			float screenAspect = (float)Screen.width / Screen.height;
			float cameraHeight = (MainCamera.orthographicSize + GameConfig.screenBorderOffset) * 2;
			Vector2 boundsSize = new(cameraHeight * screenAspect, cameraHeight);
			return new Bounds(MainCamera.transform.position, boundsSize);
		}
	}
}