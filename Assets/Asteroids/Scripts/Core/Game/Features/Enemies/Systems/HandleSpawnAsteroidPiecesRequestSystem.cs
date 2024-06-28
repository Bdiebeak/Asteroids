using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
using Asteroids.Scripts.Core.Game.Features.Requests;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Systems
{
	public class HandleSpawnAsteroidPiecesRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;

		public HandleSpawnAsteroidPiecesRequestSystem(GameplayContext gameplayContext,
													  IGameFactory gameFactory)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
		}

		public void Update()
		{
			var entities = _gameplayContext.GetRequests<SpawnAsteroidPiecesRequest>();
			foreach (Entity entity in entities)
			{
				SpawnAsteroidPiecesRequest spawnRequest = entity.Get<SpawnAsteroidPiecesRequest>();
				for (int i = 0; i < spawnRequest.count; i++)
				{
					_gameFactory.CreateEnemy(EnemyType.AsteroidPiece, spawnRequest.position);
				}
			}

			_gameplayContext.DestroyRequests<SpawnAsteroidPiecesRequest>();
		}
	}
}