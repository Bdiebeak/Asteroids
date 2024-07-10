using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Destroy.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Destroy
{
	public class DestroyFeature : Feature
	{
		private readonly ISystemsFactory _systemsFactory;

		public DestroyFeature(ISystemsFactory systemsFactory)
		{
			_systemsFactory = systemsFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemsFactory.CreateSystem<DestroySystem>()); // First to make entities live one more frame.
			systems.Add(_systemsFactory.CreateSystem<DestroyAtTimeSystem>());
			systems.Add(_systemsFactory.CreateSystem<HandleDestroyRequestSystem>());
		}
	}
}