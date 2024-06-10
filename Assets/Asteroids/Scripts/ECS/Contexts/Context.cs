using System;
using System.Collections.Generic;
using System.Linq;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.ECS.Contexts
{
	public class Context : IContext
	{
		private readonly HashSet<Entity> _entities = new();
		private Entity _uniqueEntity;

		public Entity CreateEntity()
		{
			Entity newEntity = new();
			_entities.Add(newEntity);
			return newEntity;
		}

		public void DestroyEntity(Entity entity)
		{
			if (_entities.Contains(entity) == false)
			{
				throw new InvalidOperationException("Can't remove this entity it doesn't exist in this context.");
			}
			entity.Clear();
		}

		public IReadOnlyCollection<Entity> GetEntities()
		{
			return _entities;
		}

		public IReadOnlyCollection<Entity> GetEntities(Mask mask)
		{
			HashSet<Entity> entities = new();

			var includedArray = mask.GetIncluded().ToArray();
			var excludedArray = mask.GetExcluded().ToArray();
			foreach (Entity entity in _entities)
			{
				if (entity.HasAll(includedArray) == false)
				{
					continue;
				}
				if (entity.HasAny(excludedArray))
				{
					continue;
				}

				entities.Add(entity);
			}
			return entities;
		}

		public TComponent CreateUnique<TComponent>(TComponent component) where TComponent : IUniqueComponent
		{
			Entity uniqueEntity = GetOrCreateUniqueEntity();
			if (uniqueEntity.Has<TComponent>())
			{
				throw new InvalidOperationException("Unique component was already created.");
			}
			return uniqueEntity.Add(component);
		}

		public TComponent GetUnique<TComponent>() where TComponent : IUniqueComponent
		{
			Entity uniqueEntity = GetOrCreateUniqueEntity();
			if (uniqueEntity.Has<TComponent>() == false)
			{
				throw new InvalidOperationException("Unique component wasn't created.");
			}
			return uniqueEntity.Get<TComponent>();
		}

		public void RemoveUnique<TComponent>() where TComponent : IUniqueComponent
		{
			Entity uniqueEntity = GetOrCreateUniqueEntity();
			if (uniqueEntity.Has<TComponent>() == false)
			{
				throw new InvalidOperationException("Unique component wasn't created.");
			}
			uniqueEntity.Remove<TComponent>();
			if (uniqueEntity.GetComponents().Count == 0)
			{
				DestroyEntity(uniqueEntity);
			}
		}

		private Entity GetOrCreateUniqueEntity()
		{
			if (_uniqueEntity == null)
			{
				_uniqueEntity = CreateEntity();
			}
			return _uniqueEntity;
		}
	}
}