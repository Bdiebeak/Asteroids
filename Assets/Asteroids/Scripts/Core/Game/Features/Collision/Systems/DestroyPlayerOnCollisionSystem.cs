using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Collision.Components;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.GameOver.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.Requests;
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
			_mask = new Mask().Include<CollisionEnterEvent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				CollisionEnterEvent collisionEvent = entity.Get<CollisionEnterEvent>();
				Entity playerEntity = collisionEvent.sender;
				Entity collidingEntity = collisionEvent.collision;
				if (playerEntity.Has<PlayerMarker>() && collidingEntity.Has<EnemyMarker>())
				{
					// TODO: one more system to call GameOver after player destroy
					_gameplayContext.CreateRequest(new DestroyRequest()).target = playerEntity;
					_gameplayContext.CreateEntity().Add(new GameOverEvent());
				}
			}
		}
	}
}