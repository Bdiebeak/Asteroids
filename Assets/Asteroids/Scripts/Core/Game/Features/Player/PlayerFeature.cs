using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Player.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Player
{
	public class PlayerFeature : Feature
	{
		private readonly ISystemFactory _systemFactory;

		public PlayerFeature(ISystemFactory systemFactory)
		{
			_systemFactory = systemFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemFactory.CreateSystem<SpawnPlayerSystem>());
			systems.Add(_systemFactory.CreateSystem<HandleSpawnPlayerRequestSystem>());
			systems.Add(_systemFactory.CreateSystem<DestroyPlayerOnEnemyContactSystem>());
			systems.Add(_systemFactory.CreateSystem<GameOverSystem>());
		}
	}
}