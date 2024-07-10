using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Player.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Player
{
	public class PlayerFeature : Feature
	{
		private readonly ISystemsFactory _systemsFactory;

		public PlayerFeature(ISystemsFactory systemsFactory)
		{
			_systemsFactory = systemsFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemsFactory.CreateSystem<SpawnPlayerSystem>());
			systems.Add(_systemsFactory.CreateSystem<HandleSpawnPlayerRequestSystem>());
			systems.Add(_systemsFactory.CreateSystem<DestroyPlayerOnEnemyContactSystem>());
			systems.Add(_systemsFactory.CreateSystem<GameOverSystem>());
		}
	}
}