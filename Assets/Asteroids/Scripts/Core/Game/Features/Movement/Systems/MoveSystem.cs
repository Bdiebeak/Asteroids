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
		private readonly Mask _mask;

		public MoveSystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_mask = new Mask().Include<Velocity>();
		}

		public void Update()
		{
			var movableEntities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in movableEntities)
			{
				Position position = entity.Get<Position>();
				Velocity velocity = entity.Get<Velocity>();
				position.value += velocity.value * _timeService.DeltaTime;
			}
		}
	}
}