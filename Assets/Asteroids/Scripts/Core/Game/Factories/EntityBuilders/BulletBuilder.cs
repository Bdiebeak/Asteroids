using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Factories.EntityBuilders
{
	public class BulletBuilder : EntityBuilder
	{
		private readonly BulletWeaponConfig _config;

		public BulletBuilder(BulletWeaponConfig config)
		{
			_config = config;
		}

		protected override void ConfigureEntity(IContext context, Entity entity)
		{
			entity.Add(new BulletComponent());
			entity.Add(new PositionComponent());
			entity.Add(new MoveDirectionComponent());
			entity.Add(new MoveSpeedComponent()).value = _config.speed;
			entity.Add(new MoveVelocityComponent());
		}
	}
}