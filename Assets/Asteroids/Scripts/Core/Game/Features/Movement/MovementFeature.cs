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
			systems.Add(systemsFactory.CreateSystem<ChaseTargetSystem>());
			systems.Add(systemsFactory.CreateSystem<CopyPositionSystem>());
			systems.Add(systemsFactory.CreateSystem<CopyRotationSystem>());
			systems.Add(systemsFactory.CreateSystem<HandleTeleportRequestSystem>());
			systems.Add(systemsFactory.CreateSystem<CalculateMoveVelocitySystem>());
			systems.Add(systemsFactory.CreateSystem<CalculateRotationVelocitySystem>());
			systems.Add(systemsFactory.CreateSystem<MoveSystem>());
			systems.Add(systemsFactory.CreateSystem<RotateSystem>());
		}
	}
}