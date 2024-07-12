using Asteroids.Scripts.Core.Game.Factories.Systems;
using Asteroids.Scripts.Core.Game.Features.Weapons.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Weapons
{
	public class WeaponFeatures : Feature
	{
		private readonly ISystemsFactory _systemsFactory;

		public WeaponFeatures(ISystemsFactory systemsFactory)
		{
			_systemsFactory = systemsFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemsFactory.CreateSystem<ApplyBulletAttackInputSystem>());
			systems.Add(_systemsFactory.CreateSystem<ApplyLaserAttackInputSystem>());
			systems.Add(_systemsFactory.CreateSystem<HandleShootRequestSystem>());
			systems.Add(_systemsFactory.CreateSystem<AddAttackDelaySystem>());
			systems.Add(_systemsFactory.CreateSystem<DecreaseChargesSystem>());
			systems.Add(_systemsFactory.CreateSystem<StartWeaponChargingSystem>());
			systems.Add(_systemsFactory.CreateSystem<BulletShootSystem>());
			systems.Add(_systemsFactory.CreateSystem<LaserShootSystem>());
			systems.Add(_systemsFactory.CreateSystem<DestroyOutOfBoundsBulletSystem>());
			systems.Add(_systemsFactory.CreateSystem<BulletCollisonSystem>());
			systems.Add(_systemsFactory.CreateSystem<LaserCollisionSystem>());
			systems.Add(_systemsFactory.CreateSystem<TickWeaponAttackDelaySystem>());
			systems.Add(_systemsFactory.CreateSystem<TickWeaponChargeSystem>());
			systems.Add(_systemsFactory.CreateSystem<CleanUpShotWeaponSystem>());
		}
	}
}