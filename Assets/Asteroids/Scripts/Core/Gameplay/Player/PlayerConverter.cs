using Asteroids.Scripts.Core.Gameplay.Converters;
using Asteroids.Scripts.Core.Gameplay.Movement.Components;
using Asteroids.Scripts.Core.Gameplay.Player.Components;
using Asteroids.Scripts.Core.Gameplay.Views;
using Asteroids.Scripts.Core.Infrastructure.Configs;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Gameplay.Player
{
	public class PlayerConverter : MonoConverter
	{
		protected override void OnConvert(IContext context, Entity entity)
		{
			entity.Add(new PlayerComponent());
			entity.Add(new PositionComponent());
			entity.Add(new VelocityComponent());
			entity.Add(new VelocityDragComponent()).value = GameConfig.ShipDrag;
			entity.Add(new RotationComponent());
			// TODO: RotationVelocity and RotationSpeed ???
			entity.Add(new RotationVelocityComponent());
			entity.Add(new RotationSpeedComponent()).value = GameConfig.ShipAngularSpeed;

			TransformUpdater transformUpdater = gameObject.AddComponent<TransformUpdater>();
			transformUpdater.Initialize(entity);
		}
	}
}