using System.Collections.Generic;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Features.Events
{
	public static class EventExtensions
	{
		public static TEvent CreateEvent<TEvent>(this IContext context, TEvent @event) where TEvent : IEvent
		{
			return context.CreateEntity().Add(@event);
		}

		public static void DestroyEvents<TEvent>(this IContext context) where TEvent : IEvent
		{
			var entities = context.GetEntities(new Mask().Include<TEvent>());
			foreach (Entity entity in entities)
			{
				context.DestroyEntity(entity);
			}
		}

		public static bool HasEvent<TEvent>(this IContext context) where TEvent : IEvent
		{
			var entities = context.GetEntities(new Mask().Include<TEvent>());
			return entities.Count > 0;
		}

		public static IReadOnlyCollection<Entity> GetEvents<TEvent>(this IContext context) where TEvent : IEvent
		{
			return context.GetEntities(new Mask().Include<TEvent>());
		}
	}
}