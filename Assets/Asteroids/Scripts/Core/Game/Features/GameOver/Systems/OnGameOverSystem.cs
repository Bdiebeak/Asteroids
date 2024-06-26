using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.GameOver.Components;
using Asteroids.Scripts.Core.Infrastructure.StateMachine;
using Asteroids.Scripts.Core.Infrastructure.StateMachine.States;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.GameOver.Systems
{
	public class OnGameOverSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameStateMachine _gameStateMachine;
		private readonly Mask _mask;

		public OnGameOverSystem(GameplayContext gameplayContext, IGameStateMachine gameStateMachine)
		{
			_gameplayContext = gameplayContext;
			_gameStateMachine = gameStateMachine;
			_mask = new Mask().Include<GameOverEventComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				_gameStateMachine.Enter<GameOverState>();
			}
		}
	}
}