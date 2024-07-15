using Asteroids.Scripts.Core.Game.Features.Owner.Components;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Factories.EntityBuilders
{
	public class LaserWeaponBuilder : EntityBuilder
	{
		private readonly LaserWeaponConfig _config;

		public LaserWeaponBuilder(LaserWeaponConfig config)
		{
			_config = config;
		}

		protected override void ConfigureEntity(IContext context, Entity entity)
		{
			entity.Add(new WeaponComponent());
			entity.Add(new LaserWeaponComponent());
			entity.Add(new AttackDelayComponent()).value = _config.attackDelay;
			entity.Add(new ChargeDelayComponent()).value = _config.chargingTime;
			entity.Add(new ChargesComponent
			{
				value = _config.maxCharges,
				maxValue = _config.maxCharges
			});
			entity.Add(new OwnerReference());
		}
	}
}