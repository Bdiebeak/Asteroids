using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
using Asteroids.Scripts.Core.Game.Features.Requests;
using Asteroids.Scripts.Core.Utilities.Extensions;
using Asteroids.Scripts.Core.Utilities.Services.Camera;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Systems
{
	public class HandleSpawnUfoRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;
		private readonly ICameraProvider _cameraProvider;

		public HandleSpawnUfoRequestSystem(GameplayContext gameplayContext,
										   IGameFactory gameFactory, ICameraProvider cameraProvider)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
			_cameraProvider = cameraProvider;
		}

		public void Update()
		{
			var entities = _gameplayContext.GetRequests<SpawnUfoRequest>();
			foreach (Entity entity in entities)
			{
				Vector2 position = _cameraProvider.Bounds.GetRandomEdgePosition();
				_gameFactory.CreateEnemy(EnemyType.Ufo, position);
			}

			_gameplayContext.DestroyRequests<SpawnUfoRequest>();
		}
	}
}