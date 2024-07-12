using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Input.Events;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Requests;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Events;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
{
	public class ApplyBulletAttackInputSystem : IUpdateSystem
	{
		private readonly InputContext _inputContext;
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _playerMask;

		public ApplyBulletAttackInputSystem(InputContext inputContext, GameplayContext gameplayContext)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_playerMask = new Mask().Include<PlayerMarker>();
		}

		public void Update()
		{
			var eventEntities = _inputContext.GetEvents<BulletAttackInputEvent>();
			var playerEntities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity eventEntity in eventEntities)
			{
				foreach (Entity playerEntity in playerEntities)
				{
					BulletWeapon weapon = playerEntity.Get<BulletWeapon>();
					_gameplayContext.CreateRequest(new ShootRequest
					{
						   shooter = playerEntity,
						   weapon = weapon.value
					});
				}
			}
		}
	}
}