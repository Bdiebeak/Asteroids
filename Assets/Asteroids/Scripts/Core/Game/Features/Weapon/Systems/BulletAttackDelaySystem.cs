using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
{
	public class BulletAttackDelaySystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _attackDelayMask;

		public BulletAttackDelaySystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_attackDelayMask = new Mask().Include<BulletAttackDelay>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_attackDelayMask);
			foreach (Entity entity in entities)
			{
				BulletAttackDelay attackDelay = entity.Get<BulletAttackDelay>();
				if (_timeService.Time < attackDelay.endTime)
				{
					continue;
				}

				entity.Remove<BulletAttackDelay>();
			}
		}
	}
}