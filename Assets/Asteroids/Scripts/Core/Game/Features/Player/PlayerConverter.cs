using Asteroids.Scripts.Core.Game.Converters;
using Asteroids.Scripts.Core.Game.Features.KeepInScreen.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Features.Player
{
	public class PlayerConverter : MonoConverter
	{
		protected override void OnConvert(IContext context, Entity entity)
		{
			entity.Add(new PlayerTagComponent());
			entity.Add(new PositionComponent()).value = transform.position;
			entity.Add(new VelocityComponent());
			entity.Add(new VelocityDragComponent()).value = PlayerConfig.shipDrag;
			entity.Add(new RotationComponent());
			entity.Add(new RotationVelocityComponent());
			entity.Add(new KeepInScreenComponent());
		}
	}
}