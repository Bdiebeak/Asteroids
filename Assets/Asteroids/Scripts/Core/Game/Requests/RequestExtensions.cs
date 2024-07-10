﻿using System.Collections.Generic;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Requests
{
	public static class RequestExtensions
	{
		public static TRequest CreateRequest<TRequest>(this IContext context, TRequest request) where TRequest : IRequest
		{
			return context.CreateEntity().Add(request);
		}

		public static void DestroyRequests<TRequest>(this IContext context) where TRequest : IRequest
		{
			var entities = context.GetEntities(new Mask().Include<TRequest>());
			foreach (Entity entity in entities)
			{
				context.DestroyEntity(entity);
			}
		}

		public static IReadOnlyCollection<Entity> GetRequests<TRequest>(this IContext context) where TRequest : IRequest
		{
			return context.GetEntities(new Mask().Include<TRequest>());
		}
	}
}