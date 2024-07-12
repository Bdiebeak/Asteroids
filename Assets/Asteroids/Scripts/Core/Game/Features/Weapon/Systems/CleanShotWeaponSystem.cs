using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Requests;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
{
	public class CleanShotWeaponSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _weaponMask;

		public CleanShotWeaponSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_weaponMask = new Mask().Include<WeaponMarker>()
									.Include<Shoot>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_weaponMask);
			foreach (Entity entity in entities)
			{
				entity.Remove<Shoot>();
			}
		}
	}
}