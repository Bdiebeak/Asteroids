﻿using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Infrastructure.StateMachine;
using Asteroids.Scripts.Core.Infrastructure.StateMachine.States;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Player.Systems
{
	public class GameOverSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameStateMachine _stateMachine;
		private readonly Mask _mask;

		public GameOverSystem(GameplayContext gameplayContext, IGameStateMachine stateMachine)
		{
			_gameplayContext = gameplayContext;
			_stateMachine = stateMachine;
			_mask = new Mask().Include<PlayerMarker>()
							  .Include<ToDestroy>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				_stateMachine.Enter<GameOverState>();
			}
		}
	}
}