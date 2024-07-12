﻿using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories.Game;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
using Asteroids.Scripts.Core.Utilities.Extensions;
using Asteroids.Scripts.Core.Utilities.Services.GameCamera;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Systems
{
	public class HandleSpawnAsteroidsRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;
		private readonly ICameraService _cameraService;

		public HandleSpawnAsteroidsRequestSystem(GameplayContext gameplayContext,
												 IGameFactory gameFactory, ICameraService cameraService)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
			_cameraService = cameraService;
		}

		public void Update()
		{
			var entities = _gameplayContext.GetRequests<SpawnAsteroidsRequest>();
			foreach (Entity entity in entities)
			{
				SpawnAsteroidsRequest spawnRequest = entity.Get<SpawnAsteroidsRequest>();
				for (int i = 0; i < spawnRequest.count; i++)
				{
					Vector2 position = _cameraService.Bounds.GetRandomEdgePosition();
					_gameFactory.CreateAsteroid(position);
				}
			}

			_gameplayContext.DestroyRequests<SpawnAsteroidsRequest>();
		}
	}
}