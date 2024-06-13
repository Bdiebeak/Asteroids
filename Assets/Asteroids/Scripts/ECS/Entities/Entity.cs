using System;
using System.Collections.Generic;
using System.Linq;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Exceptions;

namespace Asteroids.Scripts.ECS.Entities
{
	public class Entity
	{
		private readonly Dictionary<Type, IComponent> _components = new();

		public void Clear()
		{
			_components.Clear();
		}

		public IReadOnlyCollection<IComponent> GetComponents()
		{
			return _components.Values;
		}

		public TComponent Add<TComponent>(TComponent component) where TComponent : IComponent
		{
			Type componentType = typeof(TComponent);
			if (_components.ContainsKey(componentType))
			{
				throw new AddComponentException($"Entity already has component {componentType}. Can't add.");
			}

			_components[componentType] = component;
			return component;
		}

		public TComponent Get<TComponent>() where TComponent : IComponent
		{
			Type componentType = typeof(TComponent);
			if (Has<TComponent>() == false)
			{
				throw new NoComponentException($"Entity doesn't have component {componentType}. Can't get.");
			}

			return (TComponent)_components[componentType];
		}

		public void Remove<TComponent>() where TComponent : IComponent
		{
			Type componentType = typeof(TComponent);
			if (Has<TComponent>() == false)
			{
				throw new NoComponentException($"Entity doesn't have component {componentType}. Can't remove.");
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