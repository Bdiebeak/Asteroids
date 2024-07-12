using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Owners.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Requests;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
{
	public class HandleShootRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;

		public HandleShootRequestSystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
		}

		public void Update()
		{
			var entities = _gameplayContext.GetRequests<ShootRequest>();
			foreach (Entity entity in entities)
			{
				ShootRequest shootRequest = entity.Get<ShootRequest>();

				Entity shooter = shootRequest.shooter;
				if (_gameplayContext.IsActive(shooter) == false)
				{
					Debug.LogError("Shooter entity isn't active.");
					continue;
				}

				Entity weapon = shootRequest.weapon;
				if (_gameplayContext.IsActive(weapon) == false)
				{
					Debug.LogError("Weapon entity isn't active.");
					continue;
				}

				if (weapon.Get<Owner>().value != shooter)
				{
					Debug.LogError("Can't shoot with unowned weapon.");
					continue;
				}

				if (weapon.Has<AttackDelay>())
				{
					continue;
				}

				if (weapon.Has<Charges>())
				{
					Charges charges = weapon.Get<Charges>();
					if (charges.value == 0)
					{
						continue;
					}
				}

				weapon.Add(new Shoot());
			}

			_gameplayContext.DestroyRequests<ShootRequest>();
		}
	}
}