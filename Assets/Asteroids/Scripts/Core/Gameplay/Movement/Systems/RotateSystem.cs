using Asteroids.Scripts.Core.Gameplay.Movement.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Gameplay.Movement.Systems
{
	public class RotateSystem : IUpdateSystem
	{
		private readonly IContext _gameplayContext;
		private readonly Mask _movableMask;

		public RotateSystem(IContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_movableMask = new Mask().Include<RotationComponent>()
									 .Include<AngularDirectionComponent>()
									 .Include<AngularSpeedComponent>();
		}

		public void Update(float deltaTime)
		{
			var movableEntities = _gameplayContext.GetEntities(_movableMask);
			foreach (Entity entity in movableEntities)
			{
				RotationComponent rotation = entity.Get<RotationComponent>();
				AngularDirectionComponent angularDirection = entity.Get<AngularDirectionComponent>();
				AngularSpeedComponent angularSpeed = entity.Get<AngularSpeedComponent>();

				rotation.value += angularDirection.value * angularSpeed.value * deltaTime;
				rotation.value = (rotation.value + 180) % 360 - 180;
			}
		}
	}
}