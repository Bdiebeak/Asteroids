using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Factories.EntityBuilders
{
	public class UfoSpawnBuilder : EntityBuilder
	{
		protected override void ConfigureEntity(IContext context, Entity entity)
		{
			entity.Add(new UfoSpawnerComponent());
			entity.Add(new UfoSpawnTimerComponent());
		}
	}
}