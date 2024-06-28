using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Base;
using Asteroids.Scripts.Core.Game.Features.Weapon.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Weapon
{
	public class LaserWeaponFeature : Feature
	{
		public LaserWeaponFeature(ISystemsFactory systemsFactory) : base(systemsFactory) { }

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(systemsFactory.CreateSystem<ApplyLaserAttackInputSystem>());
			systems.Add(systemsFactory.CreateSystem<LaserAttackDelaySystem>());
			systems.Add(systemsFactory.CreateSystem<ChargeLaserSystem>());
		}
	}
}