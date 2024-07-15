using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
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

		public HandleSpawnAsteroidRequestSystem(GameplayContext gameplayContext, IGameFactory gameFactory)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
		}

		public void Update()
		{
			var entities = _gameplayContext.GetRequests<SpawnAsteroidRequest>();
			foreach (Entity entity in entities)
			{
				SpawnAsteroidRequest spawnRequest = entity.Get<SpawnAsteroidRequest>();
				_gameFactory.CreateAsteroid(spawnRequest.position, Random.insideUnitCircle.normalized);
			}

			_gameplayContext.DestroyRequests<SpawnAsteroidRequest>();
		}
	}
}