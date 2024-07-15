using System;
using System.Collections.Generic;
using System.Text;
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
			SortComponents();
			gameObject.name = GenerateName();
		}

		private void OnComponentRemoved(IComponent component)
		{
			components.RemoveAll(wrapper => wrapper.componentReference == component);
			gameObject.name = GenerateName();
		}

		private void OnEntityDestroyed()
		{
			Destroy(gameObject);
		}

		private void SortComponents()
		{
			components.Sort((x, y) => string.Compare(x.componentReference.GetType().Name,
													 y.componentReference.GetType().Name,
													 StringComparison.InvariantCulture));
		}

		private string GenerateName()
		{
			StringBuilder stringBuilder = new($"Entity {_entity.Id} - (");
			for (int i = 0; i < components.Count; i++)
			{
				stringBuilder.Append(components[i].componentReference.GetType().Name);
				if (i != components.Count - 1)
				{
					stringBuilder.Append(", ");
				}
			}
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}
	}
}