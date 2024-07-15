using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Collision;
using Asteroids.Scripts.Core.Game.Features.Collision.Events;
using Asteroids.Scripts.Core.Game.Features.Destroy.Requests;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Events;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Player.Systems
{
	public class DestroyPlayerOnEnemyContactSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;

		public DestroyPlayerOnEnemyContactSystem(GameplayContext gameplayContext)
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

				// You may wonder why the sender is always the player and there's no reverse check.
				// This is because the CollisionProvider behavior is attached to the Player prefab,
				// making the Player the Sender.
				// If the Sender were an Enemy, this logic would execute only when an event is triggered from Player.
				// This logic persists as long as the CollisionProvider remains attached to the Player.
				if (sender.Has<PlayerComponent>() && collision.Has<EnemyComponent>())
				{
					_gameplayContext.CreateRequest(new DestroyRequest()).targetEntityId = sender.Id;
				}
			}
		}
	}
}