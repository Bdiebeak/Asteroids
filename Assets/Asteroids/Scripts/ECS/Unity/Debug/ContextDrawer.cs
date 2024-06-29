using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.ECS.Unity.Debug
{
	public class ContextDrawer : MonoBehaviour
	{
		private Transform _contextTransform;
		private IContext _context;

		public void Initialize(IContext context, Transform parent = null)
		{
			_contextTransform = new GameObject($"{context.GetType().Name}").transform;
			_contextTransform.parent = parent;

			_context = context;
			_context.EntityCreated += OnEntityCreated;
		}

		private void OnDestroy()
		{
			_context.EntityCreated -= OnEntityCreated;
		}

		private void OnEntityCreated(Entity entity)
		{
			GameObject entityObject = new("Entity")
			{
				transform =
				{
					parent = _contextTransform
				}
			};
			entityObject.AddComponent<EntityDrawer>().Initialize(entity);
		}
	}
}