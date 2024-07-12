using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapons.Systems
{
	public class CleanUpShotWeaponSystem : ICleanUpSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _cleanWeaponMask;

		public CleanUpShotWeaponSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_cleanWeaponMask = new Mask().Include<WeaponComponent>()
										 .Include<ShootComponent>();
		}

		public void CleanUp()
		{
			var entities = _gameplayContext.GetEntities(_cleanWeaponMask);
			foreach (Entity entity in entities)
			{
				entity.Remove<ShootComponent>();
			}
		}
	}
}