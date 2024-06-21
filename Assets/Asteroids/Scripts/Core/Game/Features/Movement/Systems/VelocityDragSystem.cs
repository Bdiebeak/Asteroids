using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Infrastructure.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Systems
{
	public class VelocityDragSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _mask;

		public VelocityDragSystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_mask = new Mask().Include<VelocityComponent>()
							  .Include<VelocityDragComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				VelocityComponent velocity = entity.Get<VelocityComponent>();
				VelocityDragComponent drag = entity.Get<VelocityDragComponent>();
				velocity.value = Vector2.MoveTowards(velocity.value, Vector2.zero,
													 drag.value * _timeService.DeltaTime);
			}
		}
	}
}