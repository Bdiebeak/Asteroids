using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using Asteroids.Scripts.Logic.Components;

namespace Asteroids.Scripts.Logic.Systems.Movement
{
	public class MoveSystem : IUpdateSystem
	{
		private readonly IContext _gameplayContext;
		private readonly Mask _movableMask;

		public MoveSystem(IContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_movableMask = new Mask().Include<PositionComponent>()
										 .Include<MoveDirectionComponent>()
										 .Include<MoveSpeedComponent>();
		}

		public void Update(float deltaTime)
		{
			var movableEntities = _gameplayContext.GetEntities(_movableMask);
			foreach (Entity entity in movableEntities)
			{
				PositionComponent position = entity.Get<PositionComponent>();
				MoveDirectionComponent moveDirection = entity.Get<MoveDirectionComponent>();
				MoveSpeedComponent moveSpeed = entity.Get<MoveSpeedComponent>();

				// TODO: add inertia.
				position.value += moveDirection.value * moveSpeed.value * deltaTime;
			}
		}
	}
}