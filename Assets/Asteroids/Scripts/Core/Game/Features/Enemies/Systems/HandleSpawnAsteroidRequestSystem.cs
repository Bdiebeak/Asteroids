using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Score.Components;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Systems
{
	public class HandleSpawnAsteroidRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;
		private readonly IConfigService _configService;

		public HandleSpawnAsteroidRequestSystem(GameplayContext gameplayContext,
												IGameFactory gameFactory, IConfigService configService)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
			_configService = configService;
		}

		public void Update()
		{
			var entities = _gameplayContext.GetRequests<SpawnAsteroidRequest>();
			foreach (Entity entity in entities)
			{
				SpawnAsteroidRequest request = entity.Get<SpawnAsteroidRequest>();

				Entity asteroid = _gameplayContext.CreateEntity();
				asteroid.Add(new EnemyComponent());
				asteroid.Add(new AsteroidComponent());
				asteroid.Add(new PiecesComponent()).value = _configService.AsteroidConfig.piecesSpawnCount;
				asteroid.Add(new PositionComponent()).value = request.position;
				asteroid.Add(new MoveDirectionComponent()).value = Random.insideUnitCircle.normalized;
				asteroid.Add(new MoveSpeedComponent()).value = _configService.AsteroidConfig.speed;
				asteroid.Add(new MoveVelocityComponent());
				asteroid.Add(new KeepInBoundsComponent());
				asteroid.Add(new ScoreRewardComponent()).value = _configService.AsteroidConfig.score;
				_gameFactory.CreateAsteroidView(asteroid);
			}

			_gameplayContext.DestroyRequests<SpawnAsteroidRequest>();
		}
	}
}