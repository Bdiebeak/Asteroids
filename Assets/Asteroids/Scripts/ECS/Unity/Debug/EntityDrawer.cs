using System;
using System.Collections.Generic;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.ECS.Unity.Debug
{
	public class EntityDrawer : MonoBehaviour
	{
		public List<ComponentWrapper> components = new();

		private Entity _entity;

		public void Initialize(Entity entity)
		{
			_entity = entity;
			_entity.ComponentAdded += OnComponentAdded;
			_entity.ComponentRemoved += OnComponentRemoved;
			_entity.Destroyed += OnEntityDestroyed;
		}

		private void OnDestroy()
		{
			_entity.ComponentAdded -= OnComponentAdded;
			_entity.ComponentRemoved -= OnComponentRemoved;
			_entity.Destroyed -= OnEntityDestroyed;
		}

		private void OnComponentAdded(IComponent component)
		{
			components.Add(new ComponentWrapper(component));
			// Sort components alphabetically.
			components.Sort((x, y) => string.Compare(x.componentReference.GetType().Name,
													 y.componentReference.GetType().Name,
													 StringComparison.InvariantCulture));
		}

		private void OnComponentRemoved(IComponent component)
		{
			components.RemoveAll(wrapper => wrapper.componentReference == component);
		}

		private void OnEntityDestroyed()
		{
			Destroy(gameObject);
		}
	}
}