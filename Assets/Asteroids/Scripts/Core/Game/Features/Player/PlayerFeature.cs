using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Base;
using Asteroids.Scripts.Core.Game.Features.Player.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Player
{
	public class PlayerFeature : Feature
	{
		public PlayerFeature(ISystemsFactory systemsFactory) : base(systemsFactory) { }

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(systemsFactory.CreateSystem<SpawnPlayerSystem>());
			systems.Add(systemsFactory.CreateSystem<HandleSpawnPlayerRequestSystem>());
			systems.Add(systemsFactory.CreateSystem<GameOverSystem>());
		}
	}
}