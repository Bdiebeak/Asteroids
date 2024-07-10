using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Events;
using Asteroids.Scripts.Core.Game.Features.Input.Events;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Requests;
using Asteroids.Scripts.Core.Game.Requests;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
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
			_playerMask = new Mask().Include<PlayerMarker>();
		}

		public void Update()
		{
			var eventEntities = _inputContext.GetEvents<LaserAttackInputEvent>();
			var playerEntities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity eventEntity in eventEntities)
			{
				foreach (Entity playerEntity in playerEntities)
				{
					Position position = playerEntity.Get<Position>();
					Rotation rotation = playerEntity.Get<Rotation>();
					_gameplayContext.CreateRequest(new ShootLaserRequest
					{
						   shooter = playerEntity,
						   position = position.value,
						   rotation = rotation.value
					});
				}
			}
		}
	}
}