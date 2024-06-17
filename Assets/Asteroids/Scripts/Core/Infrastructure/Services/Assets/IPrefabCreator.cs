using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Services.Assets
{
	public interface IPrefabCreator
	{
		GameObject Instantiate(string assetKey, Transform parent = null);
		TComponent InstantiateComponent<TComponent>(string assetKey, Transform parent = null);
	}
}