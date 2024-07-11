using UnityEngine;

namespace Asteroids.Scripts.Core.Utilities.Services.Assets
{
	public interface IPrefabCreator
	{
		GameObject Instantiate(string assetKey, Transform parent = null);
		GameObject Instantiate(string assetKey, Vector2 position, Transform parent = null);
		GameObject Instantiate(string assetKey, Vector2 position, float rotation, Transform parent = null);
	}
}