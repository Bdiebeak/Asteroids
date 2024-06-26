using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Collision.Components;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Requests;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Collision.Systems
{
	public class LaserCollisionSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _mask;

		public LaserCollisionSystem(GameplayContext gameplayContext)
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
				Entity laserEntity = collisionEvent.sender;
				Entity collidingEntity = collisionEvent.collision;
				if (laserEntity.Has<LaserMarker>() && collidingEntity.Has<EnemyMarker>())
				{
					_gameplayContext.CreateRequest(new DestroyRequest()).target = collidingEntity;
				}
			}
		}
	}
}