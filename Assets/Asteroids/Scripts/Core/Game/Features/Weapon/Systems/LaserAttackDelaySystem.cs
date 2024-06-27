using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
{
	// TODO: this is a copy of BulletAttackDelaySystem
	// think about how to use general logic here - create hierarchy or smth like this.
	// Player - Weapons - Bullet Weapon - Attack Delay, Attack
	//                  - Laser Weapon - Attack Delay,
	// Delay feature - will be used by Weapons and UFO Spawner
	public class LaserAttackDelaySystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _mask;

		public LaserAttackDelaySystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_mask = new Mask().Include<LaserAttackDelay>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				LaserAttackDelay attackDelay = entity.Get<LaserAttackDelay>();
				if (attackDelay.endTime > _timeService.Time)
				{
					continue;
				}

				entity.Remove<LaserAttackDelay>();
			}
		}
	}
}