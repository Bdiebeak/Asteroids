using Asteroids.Scripts.Core.Game.Converters;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Converters
{
	public class BulletConverter : MonoConverter
	{
		protected override void OnConvert(IContext context, Entity entity)
		{
			entity.Add(new BulletMarker());
			entity.Add(new Position()).value = transform.position;
			entity.Add(new MoveDirection()).value = transform.up;
			entity.Add(new MoveSpeed()).value = WeaponsConfig.bulletSpeed;
			entity.Add(new MoveVelocity());
		}
	}
}