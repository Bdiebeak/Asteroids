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
			_entity.Destroyed += OnEntityDestroyed;
			gameObject.name = GenerateName();
		}

		private void OnDestroy()
		{
			_entity.Destroyed -= OnEntityDestroyed;
		}

		private void OnEntityDestroyed()
		{
			Destroy(gameObject);
		}

		public void RefillComponents()
		{
			// Bad code, but this is for Editor.
			components.Clear();
			foreach (IComponent component in _entity.GetComponents())
			{
				components.Add(new ComponentWrapper(component));
			}
			components.Sort((x, y) => string.Compare(x.componentReference.GetType().Name,
													 y.componentReference.GetType().Name,
													 StringComparison.InvariantCulture));
		}

		private string GenerateName()
		{
			return $"Entity ({_entity.Id})";
		}
	}
}