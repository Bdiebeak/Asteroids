using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapons.Systems
{
	public class TickWeaponAttackDelaySystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _attackDelayMask;

		public TickWeaponAttackDelaySystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_attackDelayMask = new Mask().Include<AttackDelayTimerComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_attackDelayMask);
			foreach (Entity entity in entities)
			{
				AttackDelayTimerComponent attackDelayTimer = entity.Get<AttackDelayTimerComponent>();
				if (attackDelayTimer.value > 0)
				{
					attackDelayTimer.value -= _timeService.DeltaTime;
					continue;
				}

				entity.Remove<AttackDelayTimerComponent>();
			}
		}
	}
}