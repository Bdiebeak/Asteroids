﻿using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Destroy.Requests;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
{
	public class DestroyOutOfBoundsBulletSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _bulletMask;

		public DestroyOutOfBoundsBulletSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_bulletMask = new Mask().Include<BulletMarker>()
									.Include<OutOfBoundsMarker>()
									.Exclude<ToDestroy>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_bulletMask);
			foreach (Entity entity in entities)
			{
				_gameplayContext.CreateRequest(new DestroyRequest()).target = entity;
			}
		}
	}
}