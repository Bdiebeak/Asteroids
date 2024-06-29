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
		void DestroyEntity(Entity entity);
		bool IsActive(Entity entity);
		IReadOnlyCollection<Entity> GetEntities();
		IReadOnlyCollection<Entity> GetEntities(Mask mask);
		void Destroy();
	}
}