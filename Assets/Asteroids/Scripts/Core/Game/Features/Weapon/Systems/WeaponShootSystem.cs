using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Requests;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
{
	public class WeaponShootSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _weaponMask;

		public WeaponShootSystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_weaponMask = new Mask().Include<WeaponMarker>()
									.Include<Shoot>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_weaponMask);
			foreach (Entity entity in entities)
			{
				if (entity.Has<Charges>())
				{
					Charges charges = entity.Get<Charges>();
					charges.value--;
				}

				entity.Add(new AttackDelay()).endTime = _timeService.Time +
														WeaponsConfig.BulletAttackDelay; // TODO: don't use config
			}
		}
	}
}