using System.Collections.Generic;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.ECS.Contexts
{
	public interface IContext
	{
		Entity CreateEntity();
		void DestroyEntity(Entity entity);
		IReadOnlyCollection<Entity> GetEntities(Filter filter);
		bool TryGetUnique<TComponent>(out TComponent uniqueComponent) where TComponent : IUniqueComponent;
		Pool<TComponent> GetComponentPool<TComponent>() where TComponent : IComponent;
	}
}