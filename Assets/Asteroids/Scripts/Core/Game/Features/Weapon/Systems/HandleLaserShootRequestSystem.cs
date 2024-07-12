using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Owners.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Requests;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
{
	public class HandleLaserShootRequestSystem : IUpdateSystem
	{
	private readonly GameplayContext _gameplayContext;
	private readonly IGameFactory _gameFactory;
	private readonly ITimeService _timeService;

	public HandleLaserShootRequestSystem(GameplayContext gameplayContext,
										 IGameFactory gameFactory, ITimeService timeService)
	{
		_gameplayContext = gameplayContext;
		_gameFactory = gameFactory;
		_timeService = timeService;
	}

	public void Update()
	{
		var entities = _gameplayContext.GetRequests<LaserShootRequest>();
		foreach (Entity entity in entities)
		{
			LaserShootRequest shootRequest = entity.Get<LaserShootRequest>();

			Entity shooter = shootRequest.shooter;
			if (_gameplayContext.IsActive(shooter) == false)
			{
				Debug.LogError("Shooter entity isn't alive.");
				continue;
			}

			Entity weapon = shootRequest.weapon;
			if (_gameplayContext.IsActive(weapon) == false)
			{
				Debug.LogError("Weapon entity isn't alive.");
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

				charges.value--;
				if (weapon.Has<ChargeTime>() == false)
				{
					weapon.Add(new ChargeTime
					{
						value = _timeService.Time +
								WeaponsConfig.LaserCooldown // TODO: don't use config
					});
				}
			}

			weapon.Add(new AttackDelay()).endTime = _timeService.Time +
													WeaponsConfig.LaserAttackDelay; // TODO: don't use config

			// TODO: use Bullet or Laser
			float destroyTime = _timeService.Time + WeaponsConfig.LaserActiveTime;
			_gameFactory.CreateLaser(shooter.Get<Position>().value, shooter.Get<Rotation>().value, shooter, destroyTime);
		}

		_gameplayContext.DestroyRequests<LaserShootRequest>();
	}
	}
}