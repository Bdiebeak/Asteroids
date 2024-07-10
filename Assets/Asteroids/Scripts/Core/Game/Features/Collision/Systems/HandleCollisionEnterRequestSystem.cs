﻿using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Events;
using Asteroids.Scripts.Core.Game.Features.Collision.Events;
using Asteroids.Scripts.Core.Game.Features.Collision.Requests;
using Asteroids.Scripts.Core.Game.Requests;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Collision.Systems
{
	public class HandleCollisionEnterRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;

		public HandleCollisionEnterRequestSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
		}

		public void Update()
		{
			_gameplayContext.DestroyEvents<CollisionEnterEvent>();

			var entities = _gameplayContext.GetRequests<ProvideCollisionEnterRequest>();
			foreach (Entity entity in entities)
			{
				ProvideCollisionEnterRequest collisionRequest = entity.Get<ProvideCollisionEnterRequest>();
				Entity senderEntity = collisionRequest.sender;
				Entity collisionEntity = collisionRequest.collision;

				if (_gameplayContext.IsActive(senderEntity) == false ||
					_gameplayContext.IsActive(collisionEntity) == false)
				{
					Debug.LogError("Collision entities aren't active. One of them or all are null or destroyed.");
					continue;
				}

				_gameplayContext.CreateEvent(new CollisionEnterEvent
				{
					sender = senderEntity,
					collision = collisionEntity
				});
			}

			_gameplayContext.DestroyRequests<ProvideCollisionEnterRequest>();
		}
	}
}