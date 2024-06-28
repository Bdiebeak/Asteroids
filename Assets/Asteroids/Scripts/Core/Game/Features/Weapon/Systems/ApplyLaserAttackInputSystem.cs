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
	public class ApplyLaserAttackInputSystem : IUpdateSystem
	{
		private readonly InputContext _inputContext;
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;
		private readonly ITimeService _timeService;
		private readonly Mask _playerMask;

		public ApplyLaserAttackInputSystem(InputContext inputContext, GameplayContext gameplayContext,
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
			var eventEntities = _inputContext.GetEvents<LaserAttackPerformedEvent>();
			var playerEntities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity eventEntity in eventEntities)
			{
				foreach (Entity playerEntity in playerEntities)
				{
					LaserCharges laserCharges = playerEntity.Get<LaserCharges>();
					if (laserCharges.value == 0)
					{
						continue;
					}

					if (playerEntity.Has<LaserAttackDelay>())
					{
						continue;
					}

					laserCharges.value--;
					playerEntity.Add(new LaserAttackDelay()).endTime = _timeService.Time +
																	   WeaponsConfig.laserAttackDelay;

					Position position = playerEntity.Get<Position>();
					Rotation rotation = playerEntity.Get<Rotation>();
					_gameFactory.CreateLaser(position.value, rotation.value);
				}
			}
		}
	}
}