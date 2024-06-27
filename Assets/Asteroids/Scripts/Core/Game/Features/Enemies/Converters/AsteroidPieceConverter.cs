using Asteroids.Scripts.Core.Game.Converters;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Converters
{
	public class AsteroidPieceConverter : MonoConverter
	{
		protected override void OnConvert(IContext context, Entity entity)
		{
			entity.Add(new AsteroidPieceMarker());
		}
	}
}