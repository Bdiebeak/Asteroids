using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Weapon.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Weapon
{
	public class BulletWeaponFeature : Feature
	{
		private readonly ISystemsFactory _systemsFactory;

		public BulletWeaponFeature(ISystemsFactory systemsFactory)
		{
			_systemsFactory = systemsFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemsFactory.CreateSystem<ApplyBulletAttackInputSystem>());
			systems.Add(_systemsFactory.CreateSystem<HandleShootBulletRequestSystem>());
			systems.Add(_systemsFactory.CreateSystem<BulletCollisonSystem>());
			systems.Add(_systemsFactory.CreateSystem<BulletAttackDelaySystem>());
			systems.Add(_systemsFactory.CreateSystem<DestroyOutOfBoundsBulletSystem>());
		}
	}
}