using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Systems
{
	public class CalculateMoveVelocitySystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _movableMask;

		public CalculateMoveVelocitySystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_movableMask = new Mask().Include<MoveDirection>()
									 .Include<MoveSpeed>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_movableMask);
			foreach (Entity entity in entities)
			{
				MoveDirection direction = entity.Get<MoveDirection>();
				MoveSpeed speed = entity.Get<MoveSpeed>();
				MoveVelocity velocity = entity.Get<MoveVelocity>();
				Vector2 currentVelocity = velocity.value;
				Vector2 targetVelocity = direction.value * speed.value;

				if (targetVelocity.sqrMagnitude > currentVelocity.sqrMagnitude)
				{
					velocity.value = Accelerate(entity, currentVelocity, targetVelocity);
				}
				else
				{
					velocity.value = Decelerate(entity, currentVelocity, targetVelocity);
				}
			}
		}

		private Vector2 Accelerate(Entity entity, Vector2 currentVelocity, Vector2 targetVelocity)
		{
			if (entity.Has<MoveAcceleration>())
			{
				float acceleration = entity.Get<MoveAcceleration>().value;
				if (acceleration <= 0)
				{
					Debug.LogWarning($"Acceleration has weird value {acceleration}. Should be greater than zero.");
				}
				return Vector2.MoveTowards(currentVelocity, targetVelocity, acceleration * _timeService.DeltaTime);
			}
			return targetVelocity;
		}

		private Vector2 Decelerate(Entity entity, Vector2 currentVelocity, Vector2 targetVelocity)
		{
			if (entity.Has<MoveDeceleration>())
			{
				float deceleration = entity.Get<MoveDeceleration>().value;
				if (deceleration <= 0)
				{
					Debug.LogWarning($"Deceleration has weird value {deceleration}. Should be greater than zero.");
				}
				return Vector2.MoveTowards(currentVelocity, targetVelocity, deceleration * _timeService.DeltaTime);
			}
			return targetVelocity;
		}
	}
}