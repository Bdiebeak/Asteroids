using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Weapons.Systems
{
	public class AddAttackDelaySystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _weaponMask;

		public AddAttackDelaySystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_weaponMask = new Mask().Include<WeaponComponent>()
									.Include<AttackDelayComponent>()
									.Include<ShootComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_weaponMask);
			foreach (Entity entity in entities)
			{
				AttackDelayComponent attackDelay = entity.Get<AttackDelayComponent>();

				if (entity.Has<AttackDelayTimerComponent>())
				{
					Debug.LogError("The weapon shot without waiting for the end of delay between shots.");
					continue;
				}
				entity.Add(new AttackDelayTimerComponent()).value = attackDelay.value;
			}
		}
	}
}