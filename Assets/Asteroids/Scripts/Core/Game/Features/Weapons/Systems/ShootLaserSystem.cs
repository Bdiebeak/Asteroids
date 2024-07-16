﻿using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Owner.Components;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Weapons.Systems
{
	public class ShootLaserSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;
		private readonly IConfigService _configService;
		private readonly Mask _weaponMask;

		public ShootLaserSystem(GameplayContext gameplayContext,
								IGameFactory gameFactory, IConfigService configService)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
			_configService = configService;
			_weaponMask = new Mask().Include<LaserWeaponComponent>()
									.Include<ShootComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_weaponMask);
			foreach (Entity entity in entities)
			{
				OwnerReference ownerReference = entity.Get<OwnerReference>();
				if (_gameplayContext.TryGetEntity(ownerReference.entityId, out Entity shooter) == false)
				{
					Debug.LogError("Can't get owner entity.");
					continue;
				}

				PositionComponent position = shooter.Get<PositionComponent>();
				RotationComponent rotation = shooter.Get<RotationComponent>();

				Entity laser = _gameplayContext.CreateEntity();
				laser.Add(new LaserComponent());
				laser.Add(new PositionComponent()).value = position.value;
				laser.Add(new RotationComponent()).value = rotation.value;
				laser.Add(new CopyTargetPositionComponent()).targetEntityId = shooter.Id;
				laser.Add(new CopyTargetRotationComponent()).targetEntityId = shooter.Id;
				laser.Add(new DestroyTimerComponent()).value = _configService.LaserWeaponConfig.activeTime;
				_gameFactory.CreateLaserView(laser);
			}
		}
	}
}