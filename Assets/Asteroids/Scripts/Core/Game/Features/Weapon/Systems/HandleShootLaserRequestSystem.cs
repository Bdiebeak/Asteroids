﻿using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Requests;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Requests;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
{
	public class HandleShootLaserRequestSystem : IUpdateSystem
	{
	private readonly GameplayContext _gameplayContext;
	private readonly IGameFactory _gameFactory;
	private readonly ITimeService _timeService;

	public HandleShootLaserRequestSystem(GameplayContext gameplayContext,
										 IGameFactory gameFactory, ITimeService timeService)
	{
		_gameplayContext = gameplayContext;
		_gameFactory = gameFactory;
		_timeService = timeService;
	}

	public void Update()
	{
		var entities = _gameplayContext.GetRequests<ShootLaserRequest>();
		foreach (Entity entity in entities)
		{
			ShootLaserRequest shootRequest = entity.Get<ShootLaserRequest>();
			Entity shooter = shootRequest.shooter;

			if (_gameplayContext.IsActive(shooter) == false)
			{
				Debug.LogError("Shooter entity isn't alive.");
				continue;
			}

			LaserCharges charges = shooter.Get<LaserCharges>();
			if (charges.value == 0)
			{
				continue;
			}

			if (shooter.Has<LaserAttackDelay>())
			{
				continue;
			}

			if (shooter.Has<LaserChargeTime>() == false)
			{
				shooter.Add(new LaserChargeTime()
				{
					value = _timeService.Time +
							WeaponsConfig.laserCooldown
				});
			}

			charges.value--;
			shooter.Add(new LaserAttackDelay()).endTime = _timeService.Time +
														  WeaponsConfig.laserAttackDelay;

			Position position = shooter.Get<Position>();
			Rotation rotation = shooter.Get<Rotation>();
			_gameFactory.CreateLaser(position.value, rotation.value);
		}

		_gameplayContext.DestroyRequests<ShootLaserRequest>();
	}
	}
}