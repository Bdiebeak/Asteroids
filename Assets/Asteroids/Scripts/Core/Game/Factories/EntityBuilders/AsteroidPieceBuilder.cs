using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Score.Components;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Factories.EntityBuilders
{
	public class AsteroidPieceBuilder : EntityBuilder
	{
		private readonly AsteroidPieceConfig _config;

		public AsteroidPieceBuilder(AsteroidPieceConfig config)
		{
			_config = config;
		}

		protected override void ConfigureEntity(IContext context, Entity entity)
		{
			entity.Add(new EnemyComponent());
			entity.Add(new AsteroidPieceComponent());
			entity.Add(new PositionComponent());
			entity.Add(new MoveDirectionComponent());
			entity.Add(new MoveSpeedComponent()).value = _config.speed;
			entity.Add(new MoveVelocityComponent());
			entity.Add(new KeepInBoundsComponent());
			entity.Add(new ScoreRewardComponent()).value = _config.score;
		}
	}
}