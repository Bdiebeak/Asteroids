using Asteroids.Scripts.Core.Game.Factories.Systems;
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
		private readonly ISystemsFactory _systemsFactory;

		public GameplayFeatures(ISystemsFactory systemsFactory)
		{
			_systemsFactory = systemsFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(new OwnerFeature(_systemsFactory));
			systems.Add(new PlayerFeature(_systemsFactory));
			systems.Add(new EnemiesFeature(_systemsFactory));
			systems.Add(new MovementFeature(_systemsFactory));
			systems.Add(new WorldBoundsFeature(_systemsFactory));
			systems.Add(new WeaponFeatures(_systemsFactory));
			systems.Add(new CollisionFeature(_systemsFactory));
			systems.Add(new ScoreFeature(_systemsFactory));
			systems.Add(new UIFeature(_systemsFactory));
			systems.Add(new DestroyFeature(_systemsFactory)); // Have to be last in features order.
		}
	}
}