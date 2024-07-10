using UnityEngine;

namespace Asteroids.Scripts.Core.Utilities.Services.GameCamera
{
	public interface ICameraService
	{
		Camera MainCamera { get; }
		Bounds Bounds { get; }

		void Initialize(Camera mainCamera);
	}
}