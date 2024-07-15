using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Destroy.Requests;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Destroy.Systems
{
	public class DestroyAtTimeSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _destroyTimerMask;

		public DestroyAtTimeSystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_destroyTimerMask = new Mask().Include<DestroyTimerComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_destroyTimerMask);
			foreach (Entity entity in entities)
			{
				DestroyTimerComponent destroyTimer = entity.Get<DestroyTimerComponent>();
				if (destroyTimer.value > 0)
				{
					destroyTimer.value -= _timeService.DeltaTime;
					continue;
				}

				_gameplayContext.CreateRequest(new DestroyRequest()).targetEntityId = entity.Id;
			}
		}
	}
}