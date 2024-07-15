using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Systems
{
	public class HandleSpawnUfoRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;

		public HandleSpawnUfoRequestSystem(GameplayContext gameplayContext, IGameFactory gameFactory)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
		}

		public void Update()
		{
			var entities = _gameplayContext.GetRequests<SpawnUfoRequest>();
			foreach (Entity entity in entities)
			{
				SpawnUfoRequest request = entity.Get<SpawnUfoRequest>();
				_gameFactory.CreateUfo(request.position);
			}

			_gameplayContext.DestroyRequests<SpawnUfoRequest>();
		}
	}
}