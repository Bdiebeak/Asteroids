using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories.Game;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
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

		public HandleSpawnAsteroidPieceRequestSystem(GameplayContext gameplayContext, IGameFactory gameFactory)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
		}

		public void Update()
		{
			var entities = _gameplayContext.GetRequests<SpawnAsteroidPieceRequest>();
			foreach (Entity entity in entities)
			{
				SpawnAsteroidPieceRequest spawnRequest = entity.Get<SpawnAsteroidPieceRequest>();
				_gameFactory.CreateAsteroidPiece(spawnRequest.position, Random.insideUnitCircle.normalized);
			}

			_gameplayContext.DestroyRequests<SpawnAsteroidPieceRequest>();
		}
	}
}