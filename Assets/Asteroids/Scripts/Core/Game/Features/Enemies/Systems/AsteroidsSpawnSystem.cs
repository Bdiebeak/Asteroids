using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
using Asteroids.Scripts.Core.Utilities.Extensions;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.Core.Utilities.Services.GameCamera;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Systems
{
	public class AsteroidsSpawnSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ICameraService _cameraService;
		private readonly IConfigService _configService;
		private readonly Mask _asteroidMask;
		private readonly Mask _pieceMask;

		public AsteroidsSpawnSystem(GameplayContext gameplayContext,
									ICameraService cameraService, IConfigService configService)
		{
			_gameplayContext = gameplayContext;
			_cameraService = cameraService;
			_configService = configService;
			_asteroidMask = new Mask().Include<AsteroidComponent>();
			_pieceMask = new Mask().Include<AsteroidPieceComponent>();
		}

		public void Update()
		{
			var asteroids = _gameplayContext.GetEntities(_asteroidMask);
			var asteroidPieces = _gameplayContext.GetEntities(_pieceMask);
			if (asteroids.Count + asteroidPieces.Count > 0)
			{
				return;
			}

			AsteroidConfig asteroidConfig = _configService.AsteroidConfig;
			for (int i = 0; i < asteroidConfig.spawnCount; i++)
			{
				_gameplayContext.CreateRequest(new SpawnAsteroidRequest
				{
					position = _cameraService.Bounds.GetRandomEdgePosition()
				});
			}
		}
	}
}