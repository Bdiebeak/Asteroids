using Asteroids.Scripts.Core.Game.Factories.Systems;
using Asteroids.Scripts.Core.Game.Features.Enemies.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Enemies
{
	public class EnemiesFeature : Feature
	{
		private readonly ISystemsFactory _systemsFactory;

		public EnemiesFeature(ISystemsFactory systemsFactory)
		{
			_systemsFactory = systemsFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemsFactory.CreateSystem<AsteroidsSpawnSystem>());
			systems.Add(_systemsFactory.CreateSystem<AsteroidPiecesSpawnSystem>());
			systems.Add(_systemsFactory.CreateSystem<UfoSpawnSystem>());
			systems.Add(_systemsFactory.CreateSystem<HandleSpawnAsteroidsRequestSystem>());
			systems.Add(_systemsFactory.CreateSystem<HandleSpawnAsteroidPiecesRequestSystem>());
			systems.Add(_systemsFactory.CreateSystem<HandleSpawnUfoRequestSystem>());
		}
	}
}