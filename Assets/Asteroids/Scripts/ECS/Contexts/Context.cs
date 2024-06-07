using System;
using System.Collections.Generic;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Extensions;

namespace Asteroids.Scripts.ECS.Contexts
{
	public class Context : IContext
	{
		private readonly Dictionary<int, Entity> _entities = new();
		private readonly Dictionary<Type, IUniqueComponent> _uniqueComponents = new();
		private readonly Dictionary<Type, IPool> _componentPools = new();

		public Entity CreateEntity()
		{
			int newId = _entities.Count;
			Entity newEntity = new(newId, this);
			_entities.Add(newId, newEntity);
			return newEntity;
		}

		public void DestroyEntity(Entity entity)
		{
			int entityId = entity.Id;
			if (_entities.ContainsKey(entityId) == false)
			{
				throw new InvalidOperationException($"Can't find entity with {entityId} id to remove it.");
			}

			_entities.Remove(entityId);
		}

		public IReadOnlyCollection<Entity> GetEntities(Filter filter)
		{
			// TODO:
			// 1. cache result somehow to avoid huge memory allocations
			// 2. very cool to find the most short list of required components (included or excluded)
			//    and iterate through it

			// Find min included pool to minimize looped searches.
			int minCount = int.MaxValue;
			IPool minPool;
			foreach (Type includedType in filter.GetIncluded())
			{
				var componentPool = GetComponentPool<>();
				if (componentPool.GetActiveCount() > minCount)
				{
					continue;
				}

				minCount = componentPool.GetActiveCount();
				minPool = componentPool;
			}

			HashSet<Entity> _entities = new();
			foreach (Entity entity in minPool.Entities)
			{
				foreach (Type includedComponent in filter.GetIncluded())
				{
					entity.Has(includedComponent);
				}
			}
		}

		public bool TryGetUnique<TComponent>(out TComponent uniqueComponent) where TComponent : IUniqueComponent
		{
			Type requiredType = typeof(TComponent);
			if (_uniqueComponents.TryGetValue(requiredType, out IUniqueComponent component))
			{
				uniqueComponent = (TComponent)component;
				return true;
			}

			uniqueComponent = default;
			return false;
		}

		public Pool<TComponent> GetComponentPool<TComponent>() where TComponent : IComponent
		{
			Type requiredType = typeof(TComponent);
			if (_componentPools.TryGetValue(requiredType, out IPool pool))
			{
				return (Pool<TComponent>)pool;
			}

			Pool<TComponent> newPool = new();
			_componentPools.Add(requiredType, newPool);
			return newPool;
		}

		public Pool
	}
}