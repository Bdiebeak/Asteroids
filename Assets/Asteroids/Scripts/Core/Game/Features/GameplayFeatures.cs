using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Collision;
using Asteroids.Scripts.Core.Game.Features.Destroy;
using Asteroids.Scripts.Core.Game.Features.Enemies;
using Asteroids.Scripts.Core.Game.Features.Movement;
using Asteroids.Scripts.Core.Game.Features.Owner;
using Asteroids.Scripts.Core.Game.Features.Player;
using Asteroids.Scripts.Core.Game.Features.Score;
using Asteroids.Scripts.Core.Game.Features.UI;
using Asteroids.Scripts.Core.Game.Features.Weapons;
using Asteroids.Scripts.Core.Game.Features.WorldBounds;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features
{
	public class GameplayFeatures : Feature
	{
		private readonly ISystemFactory _systemFactory;

		public GameplayFeatures(ISystemFactory systemFactory)
		{
			_systemFactory = systemFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(new PlayerFeature(_systemFactory));
			systems.Add(new EnemiesFeature(_systemFactory));
			systems.Add(new WorldBoundsFeature(_systemFactory));
			systems.Add(new MovementFeature(_systemFactory));
			systems.Add(new WeaponFeatures(_systemFactory));
			systems.Add(new ScoreFeature(_systemFactory));
			systems.Add(new OwnerFeature(_systemFactory));
			systems.Add(new UIFeature(_systemFactory));
			systems.Add(new CollisionFeature(_systemFactory));
			systems.Add(new DestroyFeature(_systemFactory)); // Have to be last in features order.
		}
	}
}