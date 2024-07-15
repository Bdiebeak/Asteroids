using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Movement.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Movement
{
	public class MovementFeature : Feature
	{
		private readonly ISystemFactory _systemFactory;

		public MovementFeature(ISystemFactory systemFactory)
		{
			_systemFactory = systemFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemFactory.CreateSystem<ApplyMoveInputSystem>());
			systems.Add(_systemFactory.CreateSystem<ApplyRotationInputSystem>());
			systems.Add(_systemFactory.CreateSystem<ChaseTargetSystem>());
			systems.Add(_systemFactory.CreateSystem<CopyPositionSystem>());
			systems.Add(_systemFactory.CreateSystem<CopyRotationSystem>());
			systems.Add(_systemFactory.CreateSystem<CalculateMoveVelocitySystem>());
			systems.Add(_systemFactory.CreateSystem<CalculateRotationVelocitySystem>());
			systems.Add(_systemFactory.CreateSystem<MoveSystem>());
			systems.Add(_systemFactory.CreateSystem<RotateSystem>());
			systems.Add(_systemFactory.CreateSystem<HandleTeleportRequestSystem>());
		}
	}
}