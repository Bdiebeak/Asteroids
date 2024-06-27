using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Systems
{
	public class AsteroidPiecesSpawnSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;
		private readonly Mask _mask;

		public AsteroidPiecesSpawnSystem(GameplayContext gameplayContext, IGameFactory gameFactory)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
			_mask = new Mask().Include<AsteroidMarker>()
							  .Include<ToDestroy>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				Position position = entity.Get<Position>();
				for (int i = 0; i < EnemiesConfig.asteroidPiecesCount; i++)
				{
					_gameFactory.CreateEnemy(EnemyType.AsteroidPiece, position.value);
				}
			}
		}
	}
}