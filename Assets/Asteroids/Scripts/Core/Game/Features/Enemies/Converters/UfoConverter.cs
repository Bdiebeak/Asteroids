using System.Linq;
using Asteroids.Scripts.Core.Game.Converters;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Converters
{
	public class UfoConverter : MonoConverter
	{
		protected override void OnConvert(IContext context, Entity entity)
		{
			var playerEntities = context.GetEntities(new Mask().Include<PlayerMarker>());
			if (playerEntities.Count == 0)
			{
				Debug.LogError("Can't find player to follow.");
				return;
			}

			entity.Add(new ChaseTarget()).target = playerEntities.First();
			entity.Add(new Velocity()).value = Random.insideUnitCircle.normalized *
											   EnemiesConfig.ufoSpeed;
			entity.Add(new UfoMarker());
		}
	}
}