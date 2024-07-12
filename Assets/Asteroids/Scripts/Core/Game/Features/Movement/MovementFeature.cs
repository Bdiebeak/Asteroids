using Asteroids.Scripts.Core.Game.Factories.Systems;
using Asteroids.Scripts.Core.Game.Features.Movement.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Movement
{
	public class MovementFeature : Feature
	{
		private readonly ISystemsFactory _systemsFactory;

		public MovementFeature(ISystemsFactory systemsFactory)
		{
			_systemsFactory = systemsFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemsFactory.CreateSystem<ApplyMoveInputSystem>());
			systems.Add(_systemsFactory.CreateSystem<ApplyRotationInputSystem>());
			systems.Add(_systemsFactory.CreateSystem<ChaseTargetSystem>());
			systems.Add(_systemsFactory.CreateSystem<CopyPositionSystem>());
			systems.Add(_systemsFactory.CreateSystem<CopyRotationSystem>());
			systems.Add(_systemsFactory.CreateSystem<CalculateMoveVelocitySystem>());
			systems.Add(_systemsFactory.CreateSystem<CalculateRotationVelocitySystem>());
			systems.Add(_systemsFactory.CreateSystem<MoveSystem>());
			systems.Add(_systemsFactory.CreateSystem<RotateSystem>());
			systems.Add(_systemsFactory.CreateSystem<HandleTeleportRequestSystem>());
		}
	}
}