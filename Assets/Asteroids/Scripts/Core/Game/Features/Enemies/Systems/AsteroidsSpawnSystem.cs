using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Systems
{
	public class AsteroidsSpawnSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IConfigService _configService;
		private readonly Mask _asteroidMask;
		private readonly Mask _pieceMask;

		public AsteroidsSpawnSystem(GameplayContext gameplayContext, IConfigService configService)
		{
			_gameplayContext = gameplayContext;
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
			_gameplayContext.CreateRequest(new SpawnAsteroidsRequest
			{
				count = asteroidConfig.SpawnCount
			});
		}
	}
}