using Asteroids.Scripts.DI.Container;
using UnityEngine;

namespace Asteroids.Scripts.DI.Unity.Extensions
{
	public static class UnityExtensions
	{
		public static GameObject InstantiatePrefab(this IContainer container, GameObject prefab)
		{
			GameObject gameObject = Object.Instantiate(prefab);
			container.InjectGameObject(gameObject);
			return gameObject;
		}

		public static GameObject InstantiatePrefab(this IContainer container, GameObject prefab, Vector3 position, Quaternion rotation)
		{
			GameObject gameObject = Object.Instantiate(prefab, position, rotation);
			container.InjectGameObject(gameObject);
			return gameObject;
		}

		public static GameObject InstantiatePrefab(this IContainer container, GameObject prefab, Transform parent)
		{
			GameObject gameObject = Object.Instantiate(prefab, parent);
			container.InjectGameObject(gameObject);
			return gameObject;
		}

		public static void InjectGameObject(this IContainer container, GameObject gameObject)
		{
			Component[] components = gameObject.GetComponents(typeof(Component));
			foreach (Component component in components)
			{
				container.InjectInto(component);
			}
		}
	}
}