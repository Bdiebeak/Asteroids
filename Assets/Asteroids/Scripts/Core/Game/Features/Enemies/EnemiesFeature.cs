using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Enemies.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Enemies
{
	public class EnemiesFeature : Feature
	{
		private readonly ISystemFactory _systemFactory;

		public EnemiesFeature(ISystemFactory systemFactory)
		{
			_systemFactory = systemFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemFactory.CreateSystem<AsteroidsSpawnSystem>());
			systems.Add(_systemFactory.CreateSystem<AsteroidPiecesSpawnSystem>());
			systems.Add(_systemFactory.CreateSystem<UfoSpawnSystem>());
			systems.Add(_systemFactory.CreateSystem<HandleSpawnAsteroidRequestSystem>());
			systems.Add(_systemFactory.CreateSystem<HandleSpawnAsteroidPieceRequestSystem>());
			systems.Add(_systemFactory.CreateSystem<HandleSpawnUfoRequestSystem>());
		}
	}
}