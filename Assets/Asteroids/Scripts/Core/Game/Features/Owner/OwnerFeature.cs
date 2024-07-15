using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Owner.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Owner
{
	public class OwnerFeature : Feature
	{
		private readonly ISystemFactory _systemFactory;

		public OwnerFeature(ISystemFactory systemFactory)
		{
			_systemFactory = systemFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemFactory.CreateSystem<DestroyOwnedChildrenSystem>());
		}
	}
}