using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Base;
using Asteroids.Scripts.Core.Game.Features.Enemies.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Enemies
{
	public class EnemiesFeature : Feature
	{
		public EnemiesFeature(ISystemsFactory systemsFactory) : base(systemsFactory) { }

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(systemsFactory.CreateSystem<AsteroidsSpawnSystem>());
			systems.Add(systemsFactory.CreateSystem<AsteroidPiecesSpawnSystem>());
			systems.Add(systemsFactory.CreateSystem<UfoSpawnSystem>());
			systems.Add(systemsFactory.CreateSystem<HandleSpawnAsteroidsRequestSystem>());
			systems.Add(systemsFactory.CreateSystem<HandleSpawnAsteroidPiecesRequestSystem>());
			systems.Add(systemsFactory.CreateSystem<HandleSpawnUfoRequestSystem>());
		}
	}
}