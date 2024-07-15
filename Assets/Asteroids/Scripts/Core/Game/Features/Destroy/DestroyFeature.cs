using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Destroy.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Destroy
{
	public class DestroyFeature : Feature
	{
		private readonly ISystemFactory _systemFactory;

		public DestroyFeature(ISystemFactory systemFactory)
		{
			_systemFactory = systemFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemFactory.CreateSystem<DestroySystem>()); // First to make entities live one more frame.
			systems.Add(_systemFactory.CreateSystem<HandleDestroyWithTimerRequestSystem>());
			systems.Add(_systemFactory.CreateSystem<DestroyAtTimeSystem>());
			systems.Add(_systemFactory.CreateSystem<HandleDestroyRequestSystem>());
		}
	}
}