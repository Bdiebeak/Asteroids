﻿using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Systems
{
	public class MoveSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _movableMask;

		public MoveSystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_movableMask = new Mask().Include<MoveVelocityComponent>();
		}

		public void Update()
		{
			var movableEntities = _gameplayContext.GetEntities(_movableMask);
			foreach (Entity entity in movableEntities)
			{
				PositionComponent position = entity.Get<PositionComponent>();
				MoveVelocityComponent velocity = entity.Get<MoveVelocityComponent>();
				position.value += velocity.value * _timeService.DeltaTime;
			}
		}
	}
}