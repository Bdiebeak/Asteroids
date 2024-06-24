using UnityEngine;

namespace Asteroids.Scripts.DI.Extensions
{
	public static class UnityExtensions
	{
		public static void InjectGameObject(this IContainer resolver, GameObject gameObject)
		{
			Component[] components = gameObject.GetComponents(typeof(Component));
			foreach (Component component in components)
			{
				resolver.InjectInto(component);
			}
		}
	}
}