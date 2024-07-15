using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.WorldBounds
{
	public class WorldBoundsFeature : Feature
	{
		private readonly ISystemFactory _systemFactory;

		public WorldBoundsFeature(ISystemFactory systemFactory)
		{
			_systemFactory = systemFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemFactory.CreateSystem<MarkOutOfBoundsEntitiesSystem>());
			systems.Add(_systemFactory.CreateSystem<UnmarkOutOfBoundsEntitiesSystem>());
			systems.Add(_systemFactory.CreateSystem<KeepInBoundsSystem>());
		}
	}
}