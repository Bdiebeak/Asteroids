using Asteroids.Scripts.Core.Game.Converters;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.KeepInScreen.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Converters
{
	public class EnemyConverter : MonoConverter
	{
		protected override void OnConvert(IContext context, Entity entity)
		{
			entity.Add(new EnemyTagComponent());
			entity.Add(new PositionComponent()).value = transform.position;
			entity.Add(new VelocityComponent()).value = Random.insideUnitCircle.normalized *
														EnemiesConfig.asteroidSpeed;
			entity.Add(new KeepInScreenComponent());
		}
	}
}