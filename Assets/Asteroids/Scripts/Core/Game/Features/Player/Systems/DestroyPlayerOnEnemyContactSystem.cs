using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Events;
using Asteroids.Scripts.Core.Game.Features.Collision.Events;
using Asteroids.Scripts.Core.Game.Features.Destroy.Requests;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Requests;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

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
				Entity senderEntity = collisionEvent.sender;
				Entity collisionEntity = collisionEvent.collision;

				if (senderEntity.Has<PlayerMarker>() && collisionEntity.Has<EnemyMarker>())
				{
					_gameplayContext.CreateRequest(new DestroyRequest()).target = senderEntity;
				}
			}
		}
	}
}