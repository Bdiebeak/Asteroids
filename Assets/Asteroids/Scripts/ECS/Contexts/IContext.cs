using System;
using System.Collections.Generic;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.ECS.Contexts
{
	public interface IContext
	{
		event Action<Entity> EntityCreated;

		Entity CreateEntity();
		bool TryGetEntity(int id, out Entity entity);
		void DestroyEntity(Entity entity);
		IReadOnlyCollection<Entity> GetEntities();
		IReadOnlyCollection<Entity> GetEntities(Mask mask);
		void Destroy();
	}
}