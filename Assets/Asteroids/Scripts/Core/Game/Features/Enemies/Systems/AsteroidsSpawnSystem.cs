using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
using Asteroids.Scripts.Core.Game.Requests;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Systems
{
	public class AsteroidsSpawnSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _asteroidsMask;
		private readonly Mask _piecesMask;

		public AsteroidsSpawnSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
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

			_gameplayContext.CreateRequest(new SpawnAsteroidsRequest
			{
				count = EnemiesConfig.AsteroidsWaveCount
			});
		}
	}
}