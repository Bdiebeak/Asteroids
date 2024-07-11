using Asteroids.Scripts.Core.Game.Factories;
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
			systems.Add(_systemsFactory.CreateSystem<AddOutOfBoundsMarkerSystem>());
			systems.Add(_systemsFactory.CreateSystem<RemoveOutOfBoundsMarkerSystem>());
			systems.Add(_systemsFactory.CreateSystem<KeepInBoundsSystem>());
		}
	}
}