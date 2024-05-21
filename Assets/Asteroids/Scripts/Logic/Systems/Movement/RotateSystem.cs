using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using Asteroids.Scripts.Logic.Components;

namespace Asteroids.Scripts.Logic.Systems.Movement
{
	public class RotateSystem : IUpdateSystem
	{
		private readonly IContext _gameplayContext;
		private readonly Filter _movableFilter;

		public RotateSystem(IContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_movableFilter = new Filter().Include<RotationComponent>()
										 .Include<AngularDirectionComponent>()
										 .Include<AngularSpeedComponent>();
		}

		public void Update(float deltaTime)
		{
			var movableEntities = _gameplayContext.GetEntities(_movableFilter);
			foreach (Entity entity in movableEntities)
			{
				RotationComponent rotation = entity.Get<RotationComponent>();
				AngularDirectionComponent angularDirection = entity.Get<AngularDirectionComponent>();
				AngularSpeedComponent angularSpeed = entity.Get<AngularSpeedComponent>();

				rotation.value += angularDirection.value * angularSpeed.value * deltaTime;
				// TODO: clamp rotation.angle = (rotation.angle + 180) % 360 - 180;
			}
		}
	}
}