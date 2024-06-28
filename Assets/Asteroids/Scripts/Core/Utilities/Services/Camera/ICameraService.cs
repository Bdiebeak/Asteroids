using UnityEngine;

namespace Asteroids.Scripts.Core.Utilities.Services.Camera
{
	public interface ICameraService
	{
		UnityEngine.Camera MainCamera { get; }
		Bounds Bounds { get; }

		void Initialize(UnityEngine.Camera mainCamera);
	}
}