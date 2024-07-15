using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Factories.EntityBuilders
{
	public class LaserBuilder : EntityBuilder
	{
		private readonly LaserWeaponConfig _config;

		public LaserBuilder(LaserWeaponConfig config)
		{
			_config = config;
		}

		protected override void ConfigureEntity(IContext context, Entity entity)
		{
			entity.Add(new LaserComponent());
			entity.Add(new PositionComponent());
			entity.Add(new RotationComponent());
			entity.Add(new CopyTargetPositionComponent());
			entity.Add(new CopyTargetRotationComponent());
			entity.Add(new DestroyTimerComponent()).value = _config.activeTime;
		}
	}
}