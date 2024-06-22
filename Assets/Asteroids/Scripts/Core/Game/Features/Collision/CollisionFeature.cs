using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Collision.Systems;
using Asteroids.Scripts.Core.Infrastructure.StateMachine;
using Asteroids.Scripts.ECS.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Collision
{
	public class CollisionFeature : Feature
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameStateMachine _stateMachine;

		public CollisionFeature(GameplayContext gameplayContext, IGameStateMachine stateMachine)
		{
			_gameplayContext = gameplayContext;
			_stateMachine = stateMachine;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(new PlayerCollisionSystem(_gameplayContext, _stateMachine));
			systems.Add(new CleanUpCollisionEventsSystem(_gameplayContext));
		}
	}
}