using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
using Asteroids.Scripts.Core.Game.Requests;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Systems
{
	public class UfoSpawnSystem : IStartSystem, IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _spawnTimerMask;

		public UfoSpawnSystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_spawnTimerMask = new Mask().Include<UfoSpawner>();
		}

		public void Start()
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new UfoSpawner()).spawnTime = RandomNextSpawnTime();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_spawnTimerMask);
			foreach (Entity entity in entities)
			{
				UfoSpawner spawnTime = entity.Get<UfoSpawner>();
				if (_timeService.Time < spawnTime.spawnTime)
				{
					continue;
				}
				spawnTime.spawnTime = RandomNextSpawnTime();
				_gameplayContext.CreateRequest(new SpawnUfoRequest());
			}
		}

		private float RandomNextSpawnTime()
		{
			return _timeService.Time + Random.Range(EnemiesConfig.MinUfoDelay, EnemiesConfig.MaxUfoDelay);
		}
	}
}