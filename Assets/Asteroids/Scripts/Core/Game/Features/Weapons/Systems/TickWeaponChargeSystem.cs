using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapons.Systems
{
	public class TickWeaponChargeSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _cooldownMask;

		public TickWeaponChargeSystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_cooldownMask = new Mask().Include<ChargesComponent>()
									  .Include<ChargeDelayTimerComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_cooldownMask);
			foreach (Entity entity in entities)
			{
				ChargesComponent charges = entity.Get<ChargesComponent>();

				// Wait when Charge timer will be finished.
				ChargeDelayTimerComponent chargeDelayTimer = entity.Get<ChargeDelayTimerComponent>();
				if (chargeDelayTimer.value > 0)
				{
					chargeDelayTimer.value -= _timeService.DeltaTime;
					continue;
				}

				charges.value++;
				entity.Remove<ChargeDelayTimerComponent>();
			}
		}
	}
}