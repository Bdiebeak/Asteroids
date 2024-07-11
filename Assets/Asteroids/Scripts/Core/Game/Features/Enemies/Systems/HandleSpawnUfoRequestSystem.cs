using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
using Asteroids.Scripts.Core.Utilities.Extensions;
using Asteroids.Scripts.Core.Utilities.Services.GameCamera;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Systems
{
	public class HandleSpawnUfoRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;
		private readonly ICameraService _cameraService;

		public HandleSpawnUfoRequestSystem(GameplayContext gameplayContext,
										   IGameFactory gameFactory, ICameraService cameraService)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
			_cameraService = cameraService;
		}

		public void Update()
		{
			var entities = _gameplayContext.GetRequests<SpawnUfoRequest>();
			foreach (Entity entity in entities)
			{
				Vector2 position = _cameraService.Bounds.GetRandomEdgePosition();
				_gameFactory.CreateUfo(position);
			}

			_gameplayContext.DestroyRequests<SpawnUfoRequest>();
		}
	}
}