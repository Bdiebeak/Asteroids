using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Base;
using Asteroids.Scripts.Core.Game.Features.Movement.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Movement
{
	public class MovementFeature : Feature
	{
		public MovementFeature(ISystemsFactory systemsFactory) : base(systemsFactory) { }

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(systemsFactory.CreateSystem<ApplyMoveInputSystem>());
			systems.Add(systemsFactory.CreateSystem<ApplyRotationInputSystem>());
			systems.Add(systemsFactory.CreateSystem<DragVelocitySystem>());
			systems.Add(systemsFactory.CreateSystem<MoveSystem>());
			systems.Add(systemsFactory.CreateSystem<RotateSystem>());
			systems.Add(systemsFactory.CreateSystem<FollowPositionSystem>());
			systems.Add(systemsFactory.CreateSystem<FollowRotationSystem>());
			systems.Add(systemsFactory.CreateSystem<HandleTeleportRequestSystem>());
		}
	}
}