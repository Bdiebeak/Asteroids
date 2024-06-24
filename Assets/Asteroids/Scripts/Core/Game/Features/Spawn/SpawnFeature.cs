using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Base;
using Asteroids.Scripts.Core.Game.Features.Spawn.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Spawn
{
	public class SpawnFeature : Feature
	{
		public SpawnFeature(ISystemsFactory systemsFactory) : base(systemsFactory) { }

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(systemsFactory.CreateSystem<SpawnPlayerSystem>());
			systems.Add(systemsFactory.CreateSystem<SpawnEnemySystem>());
		}
	}
}