using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Base;
using Asteroids.Scripts.Core.Game.Features.Input.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Input
{
	public class InputFeature : Feature
	{
		public InputFeature(ISystemsFactory systemsFactory) : base(systemsFactory) { }

		public override void AddTo(SystemsContainer systems)
		{
			// TODO: change components update on events.
			systems.Add(systemsFactory.CreateSystem<InitializeInputSystem>());
			systems.Add(systemsFactory.CreateSystem<UpdateMoveInputSystem>());
			systems.Add(systemsFactory.CreateSystem<UpdateRotationInputSystem>());
			systems.Add(systemsFactory.CreateSystem<UpdateBulletAttackInputSystem>());
			systems.Add(systemsFactory.CreateSystem<UpdateLaserAttackInputSystem>());
		}
	}
}