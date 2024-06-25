﻿using Asteroids.Scripts.Core.Game.Converters;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Game.Views;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Features.Weapon
{
	public class BulletConverter : MonoConverter
	{
		protected override void OnConvert(IContext context, Entity entity)
		{
			entity.Add(new BulletTagComponent());
			entity.Add(new PositionComponent()).value = transform.position;
			entity.Add(new VelocityComponent()).value = transform.up * PlayerConfig.bulletSpeed;

			// TODO: separate converter
			TransformUpdater transformUpdater = gameObject.AddComponent<TransformUpdater>();
			transformUpdater.Initialize(entity);
		}
	}
}