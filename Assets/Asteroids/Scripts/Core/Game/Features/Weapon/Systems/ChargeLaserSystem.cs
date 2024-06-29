using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
{
	public class ChargeLaserSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _cooldownMask;

		public ChargeLaserSystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_cooldownMask = new Mask().Include<LaserChargeTime>()
									  .Include<LaserCharges>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_cooldownMask);
			foreach (Entity entity in entities)
			{
				LaserCharges charges = entity.Get<LaserCharges>();
				if (entity.Has<LaserMaxCharges>())
				{
					LaserMaxCharges maxCharges = entity.Get<LaserMaxCharges>();
					if (charges.value == maxCharges.value)
					{
						continue;
					}
				}

				// TODO: сразу восстановит один заряд, нужно событие
				LaserChargeTime chargeTime = entity.Get<LaserChargeTime>();
				if (_timeService.Time < chargeTime.value)
				{
					continue;
				}
				chargeTime.value = _timeService.Time + WeaponsConfig.laserCooldown;

				int newValue = charges.value + 1;
				if (entity.Has<LaserMaxCharges>())
				{
					LaserMaxCharges maxCharges = entity.Get<LaserMaxCharges>();
					if (newValue > maxCharges.value)
					{
						newValue = maxCharges.value;
					}
				}
				charges.value = newValue;
			}
		}
	}
}