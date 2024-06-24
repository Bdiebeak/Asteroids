using UnityEngine;

namespace Asteroids.Scripts.Core.Utilities.Services.Camera
{
	public interface ICameraProvider
	{
		UnityEngine.Camera MainCamera { get; }
		Bounds Bounds { get; }

		void Initialize();
	}
}