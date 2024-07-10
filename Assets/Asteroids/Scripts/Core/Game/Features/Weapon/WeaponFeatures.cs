using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Weapon
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
			systems.Add(new BulletWeaponFeature(_systemsFactory));
			systems.Add(new LaserWeaponFeature(_systemsFactory));
		}
	}
}