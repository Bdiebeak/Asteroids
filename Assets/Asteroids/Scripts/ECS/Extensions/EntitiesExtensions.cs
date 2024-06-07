using System;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.ECS.Extensions
{
	public static class EntitiesExtensions
	{
		public static TComponent Add<TComponent>(this Entity entity) where TComponent : IComponent
		{
			return entity.Context.GetComponentPool<TComponent>().Add(entity.Id);
		}

		public static void Remove<TComponent>(this Entity entity) where TComponent : IComponent
		{
			entity.Context.GetComponentPool<TComponent>().Remove(entity.Id);
		}

		public static TComponent Get<TComponent>(this Entity entity) where TComponent : IComponent
		{
			return entity.Context.GetComponentPool<TComponent>().Get(entity.Id);
		}

		public static bool Has<TComponent>(this Entity entity) where TComponent : IComponent
		{
			return entity.Context.GetComponentPool<TComponent>().Has(entity.Id);
		}
	}
}