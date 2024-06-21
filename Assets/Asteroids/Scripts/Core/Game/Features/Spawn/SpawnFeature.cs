using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Spawn.Systems;
using Asteroids.Scripts.ECS.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Spawn
{
	public class SpawnFeature : Feature
	{
		private readonly IGameFactory _gameFactory;

		public SpawnFeature(IGameFactory gameFactory)
		{
			_gameFactory = gameFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(new SpawnPlayerSystem(_gameFactory));
			systems.Add(new SpawnEnemySystem(_gameFactory));
		}
	}
}