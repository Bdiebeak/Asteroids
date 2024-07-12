using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories.Game;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Requests;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Player.Systems
{
	public class HandleSpawnPlayerRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;
		private readonly Mask _playerMask;

		public HandleSpawnPlayerRequestSystem(GameplayContext gameplayContext, IGameFactory gameFactory)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
			_playerMask = new Mask().Include<PlayerComponent>();
		}

		public void Update()
		{
			var requestEntities = _gameplayContext.GetRequests<SpawnPlayerRequest>();
			var playerEntities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity requestEntity in requestEntities)
			{
				if (playerEntities.Count > 0)
				{
					Debug.LogError("Can't spawn player, there is already some entity.");
					continue;
				}

				SpawnPlayerRequest spawnRequest = requestEntity.Get<SpawnPlayerRequest>();
				_gameFactory.CreatePlayer(spawnRequest.position);
			}

			_gameplayContext.DestroyRequests<SpawnPlayerRequest>();
		}
	}
}