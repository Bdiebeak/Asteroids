﻿using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Collision.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Collision.Systems
{
	public class CleanUpCollisionEventsSystem : ICleanUpSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _collisionMask;

		public CleanUpCollisionEventsSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_collisionMask = new Mask().Include<CollisionEnterEvent>();
		}

		public void CleanUp()
		{
			var entities = _gameplayContext.GetEntities(_collisionMask);
			foreach (Entity entity in entities)
			{
				_gameplayContext.DestroyEntity(entity);
			}
		}
	}
}