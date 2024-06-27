using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Utilities.Services.Camera;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Systems
{
	public class AsteroidsSpawnSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;
		private readonly ICameraProvider _cameraProvider;
		private readonly Mask _asteroidsMask;
		private readonly Mask _piecesMask;

		public AsteroidsSpawnSystem(GameplayContext gameplayContext,
									IGameFactory gameFactory,
									ICameraProvider cameraProvider)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
			_cameraProvider = cameraProvider;
			_asteroidsMask = new Mask().Include<AsteroidMarker>();
			_piecesMask = new Mask().Include<AsteroidPieceMarker>();
		}

		public void Update()
		{
			var asteroids = _gameplayContext.GetEntities(_asteroidsMask);
			var asteroidPieces = _gameplayContext.GetEntities(_piecesMask);
			if (asteroids.Count + asteroidPieces.Count > 0)
			{
				return;
			}

			// TODO: respawn Asteroids request ?
			// System which detects destroy of Asteroid and create its pieces.
			Bounds bounds = _cameraProvider.Bounds;
			for (int i = 0; i < EnemiesConfig.asteroidsWaveCount; i++)
			{
				Vector2 position = Vector2.zero;
				float random = Random.Range(0f, 1f);
				float side = Random.Range(0f, 1f);
				if (random >= 0.5f)
				{
					// Spawn on left or right side.
					position.x = side >= 0.5f ? bounds.min.x : bounds.max.x;
					position.y = Random.Range(bounds.min.y, bounds.max.y);
				}
				else
				{
					// Spawn on top or bottom side.
					position.x = Random.Range(bounds.min.x, bounds.max.x);
					position.y = side >= 0.5f ? bounds.min.y : bounds.max.y;
				}
				_gameFactory.CreateEnemy(EnemyType.Asteroid, position);
			}
		}
	}
}