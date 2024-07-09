using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.ECS.Unity.Debug.Systems
{
	public class DebugContextSystem : IStartSystem, IDestroySystem
	{
		private readonly IContext _context;
		private GameObject _root;

		public DebugContextSystem(IContext context)
		{
			_context = context;
		}

		public void Start()
		{
			_root = CreateRootParent();
			_context.EntityCreated += OnEntityCreated;
		}

		public void Destroy()
		{
			_context.EntityCreated -= OnEntityCreated;
			Object.Destroy(_root);
		}

		private GameObject CreateRootParent()
		{
			GameObject rootObject = new($"{_context.GetType().Name}");
			Object.DontDestroyOnLoad(rootObject);
			return rootObject;
		}

		private void OnEntityCreated(Entity entity)
		{
			GameObject entityObject = new("Entity")
			{
				transform =
				{
					parent = _root.transform
				}
			};
			entityObject.AddComponent<EntityDrawer>().Initialize(entity);
		}
	}
}