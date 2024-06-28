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
		private readonly Mask _mask;

		public ChargeLaserSystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_mask = new Mask().Include<LaserCooldown>()
							  .Include<LaserCharges>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
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
				LaserCooldown cooldown = entity.Get<LaserCooldown>();
				if (_timeService.Time < cooldown.endTime)
				{
					continue;
				}
				cooldown.endTime = _timeService.Time + WeaponsConfig.laserCooldown;

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