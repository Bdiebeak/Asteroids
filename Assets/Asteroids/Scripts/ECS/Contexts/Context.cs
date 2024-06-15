using System;
using System.Collections.Generic;
using System.Linq;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Exceptions;

namespace Asteroids.Scripts.ECS.Contexts
{
	public class Context : IContext
	{
		private Entity _uniqueEntity;
		private readonly HashSet<Entity> _entities = new();

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
				throw new NoEntityException("Can't remove this entity it doesn't exist in this context.");
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
			_uniqueEntity ??= CreateEntity();
			return _uniqueEntity.Add(component);
		}

		public TComponent GetUnique<TComponent>() where TComponent : IUniqueComponent
		{
			if (_uniqueEntity == null)
			{
				throw new NoEntityException("Can't find unique entity.");
			}
			return _uniqueEntity.Get<TComponent>();
		}

		public void RemoveUnique<TComponent>() where TComponent : IUniqueComponent
		{
			if (_uniqueEntity == null)
			{
				throw new NoEntityException("Can't find unique entity.");
			}

			_uniqueEntity.Remove<TComponent>();
			if (_uniqueEntity.GetComponents().Count == 0)
			{
				DestroyEntity(_uniqueEntity);
			}
		}
	}
}