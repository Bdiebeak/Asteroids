using Asteroids.Scripts.DI.Container;
using UnityEngine;

namespace Asteroids.Scripts.DI.Unity.Extensions
{
	public static class UnityExtensions
	{
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