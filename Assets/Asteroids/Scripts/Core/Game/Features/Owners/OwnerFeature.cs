using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Owners.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Owners
{
	public class OwnerFeature : Feature
	{
		private readonly ISystemsFactory _systemsFactory;

		public OwnerFeature(ISystemsFactory systemsFactory)
		{
			_systemsFactory = systemsFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemsFactory.CreateSystem<DestroyOwnedChildrenSystem>());
		}
	}
}