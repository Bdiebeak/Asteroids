using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Collision;
using Asteroids.Scripts.Core.Game.Features.Collision.Events;
using Asteroids.Scripts.Core.Game.Features.Destroy.Requests;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Events;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Weapons.Systems
{
	public class BulletCollisonSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;

		public BulletCollisonSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEvents<CollisionEnterEvent>();
			foreach (Entity entity in entities)
			{
				CollisionEnterEvent collisionEvent = entity.Get<CollisionEnterEvent>();
				if (collisionEvent.TryGetEntities(_gameplayContext, out Entity sender, out Entity collision) == false)
				{
					Debug.LogError("Can't get all required Collision entities.");
					continue;
				}

				if (sender.Has<BulletComponent>() && collision.Has<EnemyComponent>())
				{
					_gameplayContext.CreateRequest(new DestroyRequest()).targetEntityId = sender.Id;
					_gameplayContext.CreateRequest(new DestroyRequest()).targetEntityId = collision.Id;
				}
			}
		}
	}
}