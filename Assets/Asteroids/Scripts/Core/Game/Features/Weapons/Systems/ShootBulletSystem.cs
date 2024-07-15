using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Owner.Components;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.Core.Utilities.Extensions;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Weapons.Systems
{
	public class ShootBulletSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;
		private readonly Mask _weaponMask;

		public ShootBulletSystem(GameplayContext gameplayContext, IGameFactory gameFactory)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
			_weaponMask = new Mask().Include<BulletWeaponComponent>()
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
				_gameFactory.CreateBullet(position.value, Vector2.up.Rotate(rotation.value));
			}
		}
	}
}