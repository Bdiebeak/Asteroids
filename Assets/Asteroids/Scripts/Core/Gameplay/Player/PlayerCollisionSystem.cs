using Asteroids.Scripts.Core.Gameplay.Collisions.Components;
using Asteroids.Scripts.Core.Gameplay.Contexts;
using Asteroids.Scripts.Core.Gameplay.Enemies.Components;
using Asteroids.Scripts.Core.Gameplay.Player.Components;
using Asteroids.Scripts.Core.Infrastructure.StateMachine;
using Asteroids.Scripts.Core.Infrastructure.StateMachine.States;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Gameplay.Player
{
	public class PlayerCollisionSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameStateMachine _gameStateMachine;
		private readonly Mask _collisionMask;

		public PlayerCollisionSystem(GameplayContext gameplayContext, IGameStateMachine gameStateMachine)
		{
			_gameplayContext = gameplayContext;
			_gameStateMachine = gameStateMachine;
			_collisionMask = new Mask().Include<CollisionEnterEventComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_collisionMask);
			foreach (Entity entity in entities)
			{
				CollisionEnterEventComponent eventComponent = entity.Get<CollisionEnterEventComponent>();
				if (eventComponent.sender.Has<PlayerComponent>() && eventComponent.collision.Has<EnemyComponent>())
				{
					_gameStateMachine.Enter<GameOverState>();
				}
			}
		}
	}
}