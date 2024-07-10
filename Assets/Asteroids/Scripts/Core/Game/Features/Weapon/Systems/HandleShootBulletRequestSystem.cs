using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Weapon.Components;
using Asteroids.Scripts.Core.Game.Features.Weapon.Requests;
using Asteroids.Scripts.Core.Game.Requests;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Systems
{
	public class HandleShootBulletRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;
		private readonly ITimeService _timeService;

		public HandleShootBulletRequestSystem(GameplayContext gameplayContext,
											  IGameFactory gameFactory, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
			_timeService = timeService;
		}

		public void Update()
		{
			var entities = _gameplayContext.GetRequests<ShootBulletRequest>();
			foreach (Entity entity in entities)
			{
				ShootBulletRequest shootRequest = entity.Get<ShootBulletRequest>();
				Entity shooter = shootRequest.shooter;

				if (_gameplayContext.IsActive(shooter) == false)
				{
					Debug.LogError("Shooter entity isn't alive.");
					continue;
				}

				if (shooter.Has<BulletAttackDelay>())
				{
					continue;
				}
				shooter.Add(new BulletAttackDelay()).endTime = _timeService.Time +
															   WeaponsConfig.BulletAttackDelay;

				_gameFactory.CreateBullet(shootRequest.position, shootRequest.direction);
			}

			_gameplayContext.DestroyRequests<ShootBulletRequest>();
		}
	}
}