using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Events;
using Asteroids.Scripts.Core.Game.Features.Input.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
{
	public class ApplyBulletAttackInputSystem : IUpdateSystem
	{
		private readonly InputContext _inputContext;
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;
		private readonly ITimeService _timeService;
		private readonly Mask _playerMask;

		public ApplyBulletAttackInputSystem(InputContext inputContext, GameplayContext gameplayContext,
											IGameFactory gameFactory, ITimeService timeService)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
			_timeService = timeService;
			_playerMask = new Mask().Include<PlayerMarker>();
		}

		public void Update()
		{
			var eventEntities = _inputContext.GetEvents<BulletAttackPerformedEvent>();
			var playerEntities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity eventEntity in eventEntities)
			{
				foreach (Entity playerEntity in playerEntities)
				{
					if (playerEntity.Has<BulletAttackDelay>())
					{
						continue;
					}
					playerEntity.Add(new BulletAttackDelay()).endTime = _timeService.Time +
																		WeaponsConfig.bulletAttackDelay;

					Position position = playerEntity.Get<Position>();
					Rotation rotation = playerEntity.Get<Rotation>();
					_gameFactory.CreateBullet(position.value, rotation.value);
				}
			}
		}
	}
}