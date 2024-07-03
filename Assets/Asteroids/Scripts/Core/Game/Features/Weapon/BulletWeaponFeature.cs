using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Base;
using Asteroids.Scripts.Core.Game.Features.Weapon.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Weapon
{
	public class BulletWeaponFeature : Feature
	{
		public BulletWeaponFeature(ISystemsFactory systemsFactory) : base(systemsFactory) { }

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(systemsFactory.CreateSystem<ApplyBulletAttackInputSystem>());
			systems.Add(systemsFactory.CreateSystem<HandleShootBulletRequestSystem>());
			systems.Add(systemsFactory.CreateSystem<BulletAttackDelaySystem>());
			systems.Add(systemsFactory.CreateSystem<DestroyOutOfBoundsBulletSystem>());
		}
	}
}