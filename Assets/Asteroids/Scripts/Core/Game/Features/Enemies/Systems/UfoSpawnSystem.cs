using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
using Asteroids.Scripts.Core.Game.Features.Requests;
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
		private readonly Mask _mask;

		public UfoSpawnSystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_mask = new Mask().Include<UfoSpawnTime>();
		}

		public void Start()
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(new UfoSpawnTime()).value = GetRandomSpawnTime();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				UfoSpawnTime spawnTime = entity.Get<UfoSpawnTime>();
				if (spawnTime.value > _timeService.Time)
				{
					continue;
				}
				spawnTime.value = _timeService.Time + GetRandomSpawnTime();
				_gameplayContext.CreateRequest(new SpawnUfoRequest());
			}
		}

		private float GetRandomSpawnTime()
		{
			return Random.Range(EnemiesConfig.minUfoDelay, EnemiesConfig.maxUfoDelay);
		}
	}
}