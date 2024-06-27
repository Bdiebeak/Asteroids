using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
using Asteroids.Scripts.Core.Game.Features.Requests;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Systems
{
	public class HandleSpawnAsteroidPiecesRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;
		private readonly Mask _mask;

		public HandleSpawnAsteroidPiecesRequestSystem(GameplayContext gameplayContext,
													  IGameFactory gameFactory)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
			_mask = new Mask().Include<SpawnAsteroidPiecesRequest>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
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