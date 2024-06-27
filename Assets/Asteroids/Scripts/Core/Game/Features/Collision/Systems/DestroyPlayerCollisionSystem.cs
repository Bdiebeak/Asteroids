using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Collision.Components;
using Asteroids.Scripts.Core.Game.Features.Destroy.Requests;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.Requests;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Collision.Systems
{
	public class DestroyPlayerCollisionSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _mask;

		public DestroyPlayerCollisionSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_mask = new Mask().Include<CollisionEnterEvent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				CollisionEnterEvent collisionEvent = entity.Get<CollisionEnterEvent>();
				Entity senderEntity = collisionEvent.sender;
				Entity collisionEntity = collisionEvent.collision;

				if (_gameplayContext.AreEntitiesAlive(senderEntity, collisionEntity) == false)
				{
					Debug.LogError("Collision entities aren't active. One of them or all are null or destroyed.");
					continue;
				}

				if (senderEntity.Has<PlayerMarker>() && collisionEntity.Has<EnemyMarker>())
				{
					_gameplayContext.CreateRequest(new DestroyRequest()).target = senderEntity;
				}
			}
		}
	}
}