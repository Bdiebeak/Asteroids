using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Owner.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.Score.Components;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Factories.EntityBuilders
{
	public class PlayerBuilder : EntityBuilder
	{
		private readonly PlayerConfig _playerConfig;
		private readonly BulletWeaponConfig _bulletWeaponConfig;
		private readonly LaserWeaponConfig _laserWeaponConfig;

		public PlayerBuilder(PlayerConfig playerConfig,
							 BulletWeaponConfig bulletWeaponConfig, LaserWeaponConfig laserWeaponConfig)
		{
			_playerConfig = playerConfig;
			_bulletWeaponConfig = bulletWeaponConfig;
			_laserWeaponConfig = laserWeaponConfig;
		}

		protected override void ConfigureEntity(IContext context, Entity entity)
		{
			entity.Add(new PlayerComponent());
			entity.Add(new PositionComponent());
			entity.Add(new MoveDirectionComponent());
			entity.Add(new MoveSpeedComponent()).value = _playerConfig.moveSpeed;
			entity.Add(new MoveVelocityComponent());
			entity.Add(new MoveAccelerationComponent()).value = _playerConfig.moveAcceleration;
			entity.Add(new MoveDecelerationComponent()).value = _playerConfig.moveDeceleration;
			entity.Add(new RotationComponent());
			entity.Add(new RotationDirectionComponent());
			entity.Add(new RotationSpeedComponent()).value = _playerConfig.rotationSpeed;
			entity.Add(new RotationVelocityComponent());
			entity.Add(new KeepInBoundsComponent());
			entity.Add(new ScoreCounterComponent());
			BuildWeapons(context, entity);
		}

		private void BuildWeapons(IContext context, Entity player)
		{
			player.Add(new BulletWeaponReference()).entityId = new BulletWeaponBuilder(_bulletWeaponConfig)
															   .With(new OwnerReference { entityId = player.Id })
															   .Build(context).Id;
			player.Add(new LaserWeaponReference()).entityId = new LaserWeaponBuilder(_laserWeaponConfig)
															  .With(new OwnerReference { entityId = player.Id })
															  .Build(context).Id;
		}
	}
}