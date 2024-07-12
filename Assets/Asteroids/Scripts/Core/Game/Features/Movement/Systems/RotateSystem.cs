using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Systems
{
	public class RotateSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _rotatableMask;

		public RotateSystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_rotatableMask = new Mask().Include<RotationVelocityComponent>();
		}

		public void Update()
		{
			var movableEntities = _gameplayContext.GetEntities(_rotatableMask);
			foreach (Entity entity in movableEntities)
			{
				RotationComponent rotation = entity.Get<RotationComponent>();
				RotationVelocityComponent velocity = entity.Get<RotationVelocityComponent>();
				rotation.value += velocity.value * _timeService.DeltaTime;
				rotation.value %= 360;
			}
		}
	}
}