using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
using Asteroids.Scripts.Core.Utilities.Extensions;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.Core.Utilities.Services.GameCamera;
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
		private readonly ITimeService _timeService;
		private readonly ICameraService _cameraService;
		private readonly IConfigService _configService;
		private readonly Mask _spawnTimerMask;

		public UfoSpawnSystem(GameplayContext gameplayContext,
							  ITimeService timeService, ICameraService cameraService, IConfigService configService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_cameraService = cameraService;
			_configService = configService;
			_spawnTimerMask = new Mask().Include<UfoSpawnerComponent>();
		}

		public void Start()
		{
			Entity spawner = _gameplayContext.CreateEntity();
			spawner.Add(new UfoSpawnerComponent());
			spawner.Add(new UfoSpawnTimerComponent()).value = RandomizeNextSpawnTime();
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
				spawnTimer.value = RandomizeNextSpawnTime();

				UfoConfig ufoConfig = _configService.UfoConfig;
				for (int i = 0; i < ufoConfig.spawnCount; i++)
				{
					_gameplayContext.CreateRequest(new SpawnUfoRequest
					{
						position = _cameraService.Bounds.GetRandomEdgePosition()
					});
				}
			}
		}

		private float RandomizeNextSpawnTime()
		{
			UfoConfig ufoConfig = _configService.UfoConfig;
			return Random.Range(ufoConfig.minSpawnTime, ufoConfig.maxSpawnTime);
		}
	}
}