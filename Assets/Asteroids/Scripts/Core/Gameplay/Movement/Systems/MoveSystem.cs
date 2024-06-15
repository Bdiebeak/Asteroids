﻿using Asteroids.Scripts.Core.Gameplay.Movement.Components;
using Asteroids.Scripts.Core.Infrastructure.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Gameplay.Movement.Systems
{
	public class MoveSystem : IUpdateSystem
	{
		private readonly IContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _movableMask;

		public MoveSystem(IContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_movableMask = new Mask().Include<PositionComponent>()
									 .Include<VelocityComponent>();
		}

		public void Update()
		{
			var movableEntities = _gameplayContext.GetEntities(_movableMask);
			foreach (Entity entity in movableEntities)
			{
				PositionComponent position = entity.Get<PositionComponent>();
				VelocityComponent velocity = entity.Get<VelocityComponent>();
				position.value += velocity.value * _timeService.DeltaTime;
			}
		}
	}
}