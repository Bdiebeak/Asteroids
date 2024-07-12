using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Owners.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Requests;
using Asteroids.Scripts.Core.Utilities.Extensions;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
{
	public class BulletShootSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;
		private readonly Mask _weaponMask;

		public BulletShootSystem(GameplayContext gameplayContext, IGameFactory gameFactory)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
			_weaponMask = new Mask().Include<BulletWeaponMarker>()
									.Include<Shoot>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_weaponMask);
			foreach (Entity entity in entities)
			{
				Entity shooter = entity.Get<Owner>().value;
				Position position = shooter.Get<Position>();
				Rotation rotation = shooter.Get<Rotation>();

				_gameFactory.CreateBullet(position.value, Vector2.up.Rotate(rotation.value));
			}
		}
	}
}