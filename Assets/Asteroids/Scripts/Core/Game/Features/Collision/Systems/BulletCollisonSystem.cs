using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Collision.Components;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Collision.Systems
{
	public class BulletCollisonSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _mask;

		public BulletCollisonSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_mask = new Mask().Include<CollisionEnterEventComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				CollisionEnterEventComponent eventComponent = entity.Get<CollisionEnterEventComponent>();
				Entity bulletEntity = eventComponent.sender;
				Entity collidingEntity = eventComponent.collision;
				if (bulletEntity.Has<BulletTagComponent>() && collidingEntity.Has<EnemyTagComponent>())
				{
					bulletEntity.Add(new DestroyComponent());
					collidingEntity.Add(new DestroyComponent());
					// TODO: spawn small asteroids
				}
			}
		}
	}
}