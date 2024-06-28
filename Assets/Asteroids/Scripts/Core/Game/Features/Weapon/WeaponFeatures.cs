﻿using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Base;
using Asteroids.Scripts.Core.Game.Features.Weapon.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Weapon
{
	public class WeaponFeatures : Feature
	{
		public WeaponFeatures(ISystemsFactory systemsFactory) : base(systemsFactory) { }

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(new BulletWeaponFeature(systemsFactory));
			systems.Add(new LaserWeaponFeature(systemsFactory));
		}
	}
}