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
	public class HandleSpawnAsteroidPieceRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;
		private readonly IConfigService _configService;

		public HandleSpawnAsteroidPieceRequestSystem(GameplayContext gameplayContext,
													 IGameFactory gameFactory, IConfigService configService)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
			_configService = configService;
		}

		public void Update()
		{
			var entities = _gameplayContext.GetRequests<SpawnAsteroidPieceRequest>();
			foreach (Entity entity in entities)
			{
				SpawnAsteroidPieceRequest request = entity.Get<SpawnAsteroidPieceRequest>();

				Entity piece = _gameplayContext.CreateEntity();
				piece.Add(new EnemyComponent());
				piece.Add(new AsteroidPieceComponent());
				piece.Add(new PositionComponent()).value = request.position;
				piece.Add(new MoveDirectionComponent()).value = Random.insideUnitCircle.normalized;
				piece.Add(new MoveSpeedComponent()).value = _configService.AsteroidPieceConfig.speed;
				piece.Add(new MoveVelocityComponent());
				piece.Add(new KeepInBoundsComponent());
				piece.Add(new ScoreRewardComponent()).value = _configService.AsteroidPieceConfig.score;
				_gameFactory.CreateAsteroidPieceView(piece);
			}

			_gameplayContext.DestroyRequests<SpawnAsteroidPieceRequest>();
		}
	}
}