using System.Collections.Generic;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.ECS.Contexts
{
	public interface IContext
	{
		Entity CreateEntity();
		void DestroyEntity(Entity entity);
		IEnumerable<Entity> GetEntities();
		IEnumerable<Entity> GetEntities(Filter filter);
		// TODO: don't use IEnumerable
		// TODO: GetSingleEntity
	}
}