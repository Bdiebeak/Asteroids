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
		public event Action<Entity> EntityCreated;

		private readonly HashSet<Entity> _entities = new();
		private int _creationIndex;

		public Entity CreateEntity()
		{
			Entity newEntity = new(_creationIndex++);
			_entities.Add(newEntity);

			EntityCreated?.Invoke(newEntity);
			return newEntity;
		}

		public bool TryGetEntity(int id, out Entity entity)
		{
			if (_entities.Any(x => x.Id == id))
			{
				entity = _entities.First(x => x.Id == id);
				return true;
			}

			entity = default;
			return false;
		}

		public void DestroyEntity(Entity entity)
		{
			if (_entities.Contains(entity) == false)
			{
				throw new NoEntityException("Can't remove this entity it doesn't exist in this context.");
			}
			_entities.Remove(entity);
			entity.Destroy();
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

		public void Destroy()
		{
			while (_entities.Count > 0)
			{
				DestroyEntity(_entities.First());
			}
		}
	}
}