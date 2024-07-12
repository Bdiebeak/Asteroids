using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Systems
{
	public class CalculateRotationVelocitySystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _rotatableMask;

		public CalculateRotationVelocitySystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_rotatableMask = new Mask().Include<RotationDirectionComponent>()
									   .Include<RotationSpeedComponent>()
									   .Include<RotationVelocityComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_rotatableMask);
			foreach (Entity entity in entities)
			{
				RotationDirectionComponent direction = entity.Get<RotationDirectionComponent>();
				RotationSpeedComponent speed = entity.Get<RotationSpeedComponent>();
				RotationVelocityComponent velocity = entity.Get<RotationVelocityComponent>();

				float targetVelocity = direction.value * speed.value;
				velocity.value = targetVelocity;
			}
		}
	}
}