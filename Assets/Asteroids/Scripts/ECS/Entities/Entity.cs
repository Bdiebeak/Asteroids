using System;
using System.Collections.Generic;
using System.Linq;
using Asteroids.Scripts.ECS.Components;

namespace Asteroids.Scripts.ECS.Entities
{
	public class Entity
	{
		private readonly Dictionary<Type, IComponent> _components = new();

		public IReadOnlyCollection<IComponent> GetComponents()
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

		public void Remove<TComponent>() where TComponent : IComponent
		{
			Type componentType = typeof(TComponent);
			if (Has<TComponent>() == false)
			{
				throw new InvalidOperationException($"Entity doesn't have component {componentType}. Can't remove.");
			}

			_components.Remove(componentType);
		}

		public bool Has<TComponent>() where TComponent : IComponent
		{
			Type componentType = typeof(TComponent);
			return _components.ContainsKey(componentType);
		}

		public bool HasAll(params Type[] componentTypes)
		{
			return componentTypes.All(componentType => _components.ContainsKey(componentType));
		}

		public bool HasAny(params Type[] componentTypes)
		{
			return componentTypes.Any(componentType => _components.ContainsKey(componentType));
		}
	}
}