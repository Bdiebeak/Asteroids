using Asteroids.Scripts.Core.Game.Factories.Systems;
using Asteroids.Scripts.Core.Game.Features.Input.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Input
{
	public class MotionInputFeature : Feature
	{
		private readonly ISystemsFactory _systemsFactory;

		public MotionInputFeature(ISystemsFactory systemsFactory)
		{
			_systemsFactory = systemsFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemsFactory.CreateSystem<UpdateMoveInputSystem>());
			systems.Add(_systemsFactory.CreateSystem<UpdateRotationInputSystem>());
		}
	}
}