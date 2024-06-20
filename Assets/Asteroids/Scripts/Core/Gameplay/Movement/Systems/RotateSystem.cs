using Asteroids.Scripts.Core.Gameplay.Movement.Components;
using Asteroids.Scripts.Core.Infrastructure.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Gameplay.Movement.Systems
{
	public class RotateSystem : IUpdateSystem
	{
		private readonly IContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _movableMask;

		public RotateSystem(IContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_movableMask = new Mask().Include<RotationComponent>()
									 .Include<RotationVelocityComponent>();
		}

		public void Update()
		{
			var movableEntities = _gameplayContext.GetEntities(_movableMask);
			foreach (Entity entity in movableEntities)
			{
				RotationComponent rotation = entity.Get<RotationComponent>();
				RotationVelocityComponent rotationVelocity = entity.Get<RotationVelocityComponent>();
				rotation.value += rotationVelocity.value * _timeService.DeltaTime;
				rotation.value %= 360;
			}
		}
	}
}