using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.Core.Game.Features.Weapons.Requests;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Weapons.Systems
{
	public class HandleShootRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;

		public HandleShootRequestSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
		}

		public void Update()
		{
			var entities = _gameplayContext.GetRequests<ShootRequest>();
			foreach (Entity entity in entities)
			{
				ShootRequest shootRequest = entity.Get<ShootRequest>();
				if (_gameplayContext.TryGetEntity(shootRequest.weaponEntityId, out Entity weapon) == false)
				{
					Debug.LogError("Can't get weapon.");
					continue;
				}

				if (weapon.Has<WeaponComponent>() == false)
				{
					Debug.LogError("Entity in request isn't weapon. Can't shoot.");
					continue;
				}

				if (weapon.Has<AttackDelayTimerComponent>())
				{
					continue;
				}

				if (weapon.Has<ChargesComponent>())
				{
					ChargesComponent charges = weapon.Get<ChargesComponent>();
					if (charges.value == 0)
					{
						continue;
					}
				}

				weapon.Add(new ShootComponent());
			}

			_gameplayContext.DestroyRequests<ShootRequest>();
		}
	}
}