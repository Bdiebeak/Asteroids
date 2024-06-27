using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Base;
using Asteroids.Scripts.Core.Game.Features.Input.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Input
{
	public class MotionInputFeature : Feature
	{
		public MotionInputFeature(ISystemsFactory systemsFactory) : base(systemsFactory) { }

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(systemsFactory.CreateSystem<UpdateMoveInputSystem>());
			systems.Add(systemsFactory.CreateSystem<UpdateRotationInputSystem>());
		}
	}
}