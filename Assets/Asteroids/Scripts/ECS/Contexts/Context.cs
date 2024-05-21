using System;
using System.Collections.Generic;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.ECS.Contexts
{
	public class Context : IContext
	{
		private readonly Dictionary<int, Entity> _entities = new();

		public Entity CreateEntity()
		{
			int newId = _entities.Count;
			Entity newEntity = new(newId);
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

		public IEnumerable<Entity> GetEntities()
		{
			return _entities.Values;
		}

		public IEnumerable<Entity> GetEntities(Filter filter)
		{
			foreach (Entity entity in _entities.Values)
			{
				bool match = true;

				// Sort by included components.
				var includedComponents = filter.GetIncluded();
				foreach (Type type in includedComponents)
				{
					if (entity.Has(type) == false)
					{
						match = false;
						break;
					}
				}
				if (match == false)
				{
					continue;
				}

				// Sort by excluded components.
				var excludedComponents = filter.GetExcluded();
				foreach (Type type in excludedComponents)
				{
					if (entity.Has(type))
					{
						match = false;
						break;
					}
				}
				if (match == false)
				{
					continue;
				}

				yield return entity;
			}
		}
	}
}