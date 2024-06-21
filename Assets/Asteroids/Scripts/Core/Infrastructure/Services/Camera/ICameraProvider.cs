using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Services.Camera
{
	public interface ICameraProvider
	{
		UnityEngine.Camera MainCamera { get; }
		Bounds Bounds { get; }
	}
}