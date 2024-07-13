﻿using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapons.Systems
{
	public class StartWeaponChargingSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _weaponMask;

		public StartWeaponChargingSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_weaponMask = new Mask().Include<WeaponComponent>()
									.Include<ChargesComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_weaponMask);
			foreach (Entity entity in entities)
			{
				ChargesComponent charges = entity.Get<ChargesComponent>();

				// Don't charge if current charges aren't less than max.
				if (charges.value >= charges.maxValue)
				{
					continue;
				}

				// Start recharging weapon if it wasn't started earlier.
				ChargeDelayComponent chargeDelay = entity.Get<ChargeDelayComponent>();
				if (entity.Has<ChargeDelayTimerComponent>() == false)
				{
					entity.Add(new ChargeDelayTimerComponent()).value = chargeDelay.value;
				}
			}
		}
	}
}