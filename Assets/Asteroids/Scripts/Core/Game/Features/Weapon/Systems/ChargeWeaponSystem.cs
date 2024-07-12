using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
{
	public class ChargeWeaponSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _cooldownMask;

		public ChargeWeaponSystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_cooldownMask = new Mask().Include<Charges>();
		}

		// TODO: split logic - add and remove in different systems
		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_cooldownMask);
			foreach (Entity entity in entities)
			{
				Charges charges = entity.Get<Charges>();
				if (entity.Has<MaxCharges>())
				{
					MaxCharges maxCharges = entity.Get<MaxCharges>();
					if (charges.value == maxCharges.value)
					{
						if (entity.Has<ChargeTime>())
						{
							entity.Remove<ChargeTime>();
						}
						continue;
					}

					if (charges.value < maxCharges.value)
					{
						if (entity.Has<ChargeTime>() == false)
						{
							entity.Add(new ChargeTime()).value = _timeService.Time + WeaponsConfig.LaserCooldown; // TODO: don't use config
						}
					}
				}

				ChargeTime chargeTime = entity.Get<ChargeTime>();
				if (_timeService.Time < chargeTime.value)
				{
					continue;
				}
				chargeTime.value = _timeService.Time + WeaponsConfig.LaserCooldown; // TODO: don't use config
				charges.value++;
			}
		}
	}
}