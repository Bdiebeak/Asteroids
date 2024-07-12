using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories.Entities;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Systems
{
	public class UfoSpawnSystem : IStartSystem, IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IEntityFactory _entityFactory;
		private readonly ITimeService _timeService;
		private readonly Mask _spawnTimerMask;

		public UfoSpawnSystem(GameplayContext gameplayContext,
							  IEntityFactory entityFactory, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_entityFactory = entityFactory;
			_timeService = timeService;
			_spawnTimerMask = new Mask().Include<UfoSpawnerComponent>();
		}

		public void Start()
		{
			_entityFactory.CreateUfoSpawner(RandomNextSpawnTime());
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_spawnTimerMask);
			foreach (Entity entity in entities)
			{
				UfoSpawnTimerComponent spawnTimer = entity.Get<UfoSpawnTimerComponent>();
				if (spawnTimer.value > 0)
				{
					spawnTimer.value -= _timeService.DeltaTime;
					continue;
				}

				spawnTimer.value = RandomNextSpawnTime();
				_gameplayContext.CreateRequest(new SpawnUfoRequest());
			}
		}

		private float RandomNextSpawnTime()
		{
			return Random.Range(EnemiesConfig.MinUfoDelay, EnemiesConfig.MaxUfoDelay);
		}
	}
}