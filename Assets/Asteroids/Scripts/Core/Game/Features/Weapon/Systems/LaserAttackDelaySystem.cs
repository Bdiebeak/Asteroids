using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
{
	// It looks like a copy of BulletAttackDelaySystem.
	// We can create a new feature (e.g. DelayFeature) to implement similar delay logic,
	// but I don't want to complicate this project because it has final requirements.
	public class LaserAttackDelaySystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _attackDelayMask;

		public LaserAttackDelaySystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_attackDelayMask = new Mask().Include<LaserAttackDelay>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_attackDelayMask);
			foreach (Entity entity in entities)
			{
				LaserAttackDelay attackDelay = entity.Get<LaserAttackDelay>();
				if (_timeService.Time < attackDelay.endTime)
				{
					continue;
				}

				entity.Remove<LaserAttackDelay>();
			}
		}
	}
}