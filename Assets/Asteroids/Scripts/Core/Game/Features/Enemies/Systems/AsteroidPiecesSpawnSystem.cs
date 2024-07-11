using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Systems
{
	public class AsteroidPiecesSpawnSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _asteroidMask;

		public AsteroidPiecesSpawnSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_asteroidMask = new Mask().Include<AsteroidMarker>()
									  .Include<ToDestroy>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_asteroidMask);
			foreach (Entity entity in entities)
			{
				Position position = entity.Get<Position>();
				_gameplayContext.CreateRequest(new SpawnAsteroidPiecesRequest
				{
					position = position.value,
					count = EnemiesConfig.AsteroidPiecesCount
				});
			}
		}
	}
}