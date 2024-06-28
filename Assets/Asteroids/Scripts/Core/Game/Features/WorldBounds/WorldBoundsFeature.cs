using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Base;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.WorldBounds
{
	public class WorldBoundsFeature : Feature
	{
		public WorldBoundsFeature(ISystemsFactory systemsFactory) : base(systemsFactory) { }

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(systemsFactory.CreateSystem<AddOutOfBoundsSystem>());
			systems.Add(systemsFactory.CreateSystem<RemoveOutOfBoundsSystem>());
			systems.Add(systemsFactory.CreateSystem<KeepInBoundsSystem>());
		}
	}
}