using Asteroids.Scripts.Core.Game.Converters;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Features.Player.Converters
{
	public class PlayerConverter : MonoConverter
	{
		protected override void OnConvert(IContext context, Entity entity)
		{
			entity.Add(new PlayerMarker());
			entity.Add(new Position()).value = transform.position;
			entity.Add(new Velocity());
			entity.Add(new VelocityDrag()).value = PlayerConfig.shipDrag;
			entity.Add(new Rotation());
			entity.Add(new RotationVelocity());
			entity.Add(new KeepInBoundsMarker());
		}
	}
}