using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Collision.Components;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.GameOver.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Collision.Systems
{
	public class DestroyPlayerOnCollisionSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _mask;

		public DestroyPlayerOnCollisionSystem(GameplayContext gameplayContext)
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
				Entity playerEntity = eventComponent.sender;
				Entity collidingEntity = eventComponent.collision;
				if (playerEntity.Has<PlayerTagComponent>() && collidingEntity.Has<EnemyTagComponent>())
				{
					playerEntity.Add(new DestroyComponent()); // TODO: one more system to call GameOver after player destroy
					_gameplayContext.CreateEntity().Add(new GameOverEventComponent());
				}
			}
		}
	}
}