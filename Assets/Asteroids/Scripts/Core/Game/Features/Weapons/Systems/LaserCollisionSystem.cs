using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Collision.Events;
using Asteroids.Scripts.Core.Game.Features.Destroy.Requests;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Events;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapons.Systems
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
			var entities = _gameplayContext.GetEvents<ValidCollisionEnterEvent>();
			foreach (Entity entity in entities)
			{
				ValidCollisionEnterEvent collisionEvent = entity.Get<ValidCollisionEnterEvent>();
				Entity senderEntity = collisionEvent.sender;
				Entity collisionEntity = collisionEvent.collision;

				if (senderEntity.Has<LaserComponent>() && collisionEntity.Has<EnemyComponent>())
				{
					_gameplayContext.CreateRequest(new DestroyRequest()).target = collisionEntity;
				}
			}
		}
	}
}