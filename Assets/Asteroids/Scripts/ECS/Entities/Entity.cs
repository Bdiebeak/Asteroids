using System;
using System.Collections.Generic;
using Asteroids.Scripts.ECS.Components;

namespace Asteroids.Scripts.ECS.Entities
{
	public class Entity : IEntity
	{
		public int Id { get; private set; }

		private readonly Dictionary<Type, IComponent> _components = new();

		public Entity(int id)
		{
			Id = id;
		}

		public IEnumerable<IComponent> GetComponents()
		{
			return _components.Values;
		}

		public TComponent Add<TComponent>() where TComponent : IComponent, new()
		{
			Type componentType = typeof(TComponent);
			if (_components.ContainsKey(componentType))
			{
				throw new InvalidOperationException($"Entity already has component {componentType}. Can't add.");
			}

			TComponent newComponent = new();
			_components[componentType] = newComponent;
			return newComponent;
		}

		public TComponent Get<TComponent>() where TComponent : IComponent
		{
			Type componentType = typeof(TComponent);
			if (Has<TComponent>() == false)
			{
				throw new InvalidOperationException($"Entity doesn't have component {componentType}. Can't get.");
			}

			return (TComponent)_components[componentType];
		}

		public bool Has<TComponent>() where TComponent : IComponent
		{
			Type componentType = typeof(TComponent);
			return _components.ContainsKey(componentType);
		}

		public bool Has(Type componentType)
		{
			return _components.ContainsKey(componentType);
		}

		public void Remove<TComponent>() where TComponent : IComponent
		{
			Type componentType = typeof(TComponent);
			if (Has<TComponent>() == false)
			{
				throw new InvalidOperationException($"Entity doesn't have component {componentType}. Can't remove.");
			}

			_components.Remove(componentType);
		}
	}
}