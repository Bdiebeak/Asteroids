using Asteroids.Scripts.Core.Gameplay.Converters;
using Asteroids.Scripts.Core.Gameplay.Movement.Components;
using Asteroids.Scripts.Core.Gameplay.Player.Components;
using Asteroids.Scripts.Core.Infrastructure.Configs;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Gameplay.Player
{
	public class PlayerConverter : MonoConverter
	{
		protected override void OnConvert(IContext context, Entity entity)
		{
			entity.Add<PlayerComponent>(new PlayerComponent());
			// TODO: entity.ConfigureWithMovement();
			entity.Add<PositionComponent>(new PositionComponent());
			entity.Add<VelocityComponent>(new VelocityComponent());
			entity.Add<VelocityDragComponent>(new VelocityDragComponent()).value = GameConfig.ShipDrag;
			// TODO: entity.ConfigureWithRotation();
			entity.Add<RotationComponent>(new RotationComponent());
			entity.Add<RotationVelocityComponent>(new RotationVelocityComponent());
			entity.Add<RotationSpeedComponent>(new RotationSpeedComponent()).value = GameConfig.ShipAngularSpeed;

			TransformUpdater transformUpdater = gameObject.AddComponent<TransformUpdater>();
			transformUpdater.Initialize(entity);
		}
	}
}