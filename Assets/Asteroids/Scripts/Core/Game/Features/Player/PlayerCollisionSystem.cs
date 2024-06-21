using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Collision.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Infrastructure.StateMachine;
using Asteroids.Scripts.Core.Infrastructure.StateMachine.States;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Player
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
				if (eventComponent.sender.Has<PlayerTagComponent>() && eventComponent.collision.Has<EnemyTagComponent>())
				{
					_gameStateMachine.Enter<GameOverState>();
				}
			}
		}
	}
}