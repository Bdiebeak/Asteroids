using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Weapon.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Weapon
{
	public class LaserWeaponFeature : Feature
	{
		private readonly ISystemsFactory _systemsFactory;

		public LaserWeaponFeature(ISystemsFactory systemsFactory)
		{
			_systemsFactory = systemsFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemsFactory.CreateSystem<ApplyLaserAttackInputSystem>());
			systems.Add(_systemsFactory.CreateSystem<HandleShootLaserRequestSystem>());
			systems.Add(_systemsFactory.CreateSystem<LaserCollisionSystem>());
			systems.Add(_systemsFactory.CreateSystem<LaserAttackDelaySystem>());
			systems.Add(_systemsFactory.CreateSystem<ChargeLaserSystem>());
		}
	}
}