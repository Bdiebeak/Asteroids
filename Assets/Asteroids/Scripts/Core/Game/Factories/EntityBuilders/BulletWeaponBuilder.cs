using Asteroids.Scripts.Core.Game.Features.Owner.Components;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Factories.EntityBuilders
{
	public class BulletWeaponBuilder : EntityBuilder
	{
		private readonly BulletWeaponConfig _config;

		public BulletWeaponBuilder(BulletWeaponConfig config)
		{
			_config = config;
		}

		protected override void ConfigureEntity(IContext context, Entity entity)
		{
			entity.Add(new WeaponComponent());
			entity.Add(new BulletWeaponComponent());
			entity.Add(new AttackDelayComponent()).value = _config.attackDelay;
			entity.Add(new OwnerReference());
		}
	}
}