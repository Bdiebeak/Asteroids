﻿using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Events;
using Asteroids.Scripts.Core.Game.Features.Collision.Events;
using Asteroids.Scripts.Core.Game.Features.Destroy.Requests;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Game.Requests;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
{
	public class LaserCollisionSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;

		public LaserCollisionSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEvents<CollisionEnterEvent>();
			foreach (Entity entity in entities)
			{
				CollisionEnterEvent collisionEvent = entity.Get<CollisionEnterEvent>();
				Entity senderEntity = collisionEvent.sender;
				Entity collisionEntity = collisionEvent.collision;

				if (senderEntity.Has<LaserMarker>() && collisionEntity.Has<EnemyMarker>())
				{
					_gameplayContext.CreateRequest(new DestroyRequest()).target = collisionEntity;
				}
			}
		}
	}
}