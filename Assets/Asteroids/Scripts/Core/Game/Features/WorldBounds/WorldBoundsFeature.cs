using Asteroids.Scripts.Core.Game.Factories.Systems;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.WorldBounds
{
	public class WorldBoundsFeature : Feature
	{
		private readonly ISystemsFactory _systemsFactory;

		public WorldBoundsFeature(ISystemsFactory systemsFactory)
		{
			_systemsFactory = systemsFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemsFactory.CreateSystem<MarkOutOfBoundsEntitiesSystem>());
			systems.Add(_systemsFactory.CreateSystem<UnmarkOutOfBoundsEntitiesSystem>());
			systems.Add(_systemsFactory.CreateSystem<KeepInBoundsSystem>());
		}
	}
}