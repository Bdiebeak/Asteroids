using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Weapons.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Weapons
{
	public class WeaponFeatures : Feature
	{
		private readonly ISystemFactory _systemFactory;

		public WeaponFeatures(ISystemFactory systemFactory)
		{
			_systemFactory = systemFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemFactory.CreateSystem<ApplyBulletAttackInputSystem>());
			systems.Add(_systemFactory.CreateSystem<ApplyLaserAttackInputSystem>());
			systems.Add(_systemFactory.CreateSystem<HandleShootRequestSystem>());
			systems.Add(_systemFactory.CreateSystem<AddAttackDelaySystem>());
			systems.Add(_systemFactory.CreateSystem<DecreaseChargesSystem>());
			systems.Add(_systemFactory.CreateSystem<StartWeaponChargingSystem>());
			systems.Add(_systemFactory.CreateSystem<ShootBulletSystem>());
			systems.Add(_systemFactory.CreateSystem<ShootLaserSystem>());
			systems.Add(_systemFactory.CreateSystem<DestroyOutOfBoundsBulletSystem>());
			systems.Add(_systemFactory.CreateSystem<BulletCollisonSystem>());
			systems.Add(_systemFactory.CreateSystem<LaserCollisionSystem>());
			systems.Add(_systemFactory.CreateSystem<TickWeaponAttackDelaySystem>());
			systems.Add(_systemFactory.CreateSystem<TickWeaponChargeSystem>());
			systems.Add(_systemFactory.CreateSystem<CleanUpShotWeaponSystem>());
		}
	}
}