using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Input.Events;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.Weapons.Components;
using Asteroids.Scripts.Core.Game.Features.Weapons.Requests;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Events;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapons.Systems
{
	public class ApplyLaserAttackInputSystem : IUpdateSystem
	{
		private readonly InputContext _inputContext;
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _playerMask;

		public ApplyLaserAttackInputSystem(InputContext inputContext, GameplayContext gameplayContext)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_playerMask = new Mask().Include<PlayerComponent>();
		}

		public void Update()
		{
			var eventEntities = _inputContext.GetEvents<LaserAttackInputEvent>();
			var playerEntities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity eventEntity in eventEntities)
			{
				foreach (Entity playerEntity in playerEntities)
				{
					LaserWeaponReference weapon = playerEntity.Get<LaserWeaponReference>();
					_gameplayContext.CreateRequest(new ShootRequest
					{
						   weapon = weapon.value
					});
				}
			}
		}
	}
}