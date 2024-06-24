using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Collision;
using Asteroids.Scripts.Core.Game.Features.KeepInScreen;
using Asteroids.Scripts.Core.Game.Features.Movement;
using Asteroids.Scripts.Core.Game.Features.Spawn;
using Asteroids.Scripts.Core.Game.Features.UI;
using Asteroids.Scripts.Core.Utilities.Extensions;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Base
{
	public class GameplayFeature : Feature
	{
		public GameplayFeature(ISystemsFactory systemsFactory) : base(systemsFactory) { }

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(new SpawnFeature(systemsFactory));
			systems.Add(new MovementFeature(systemsFactory));
			systems.Add(new KeepInScreenFeature(systemsFactory));
			systems.Add(new CollisionFeature(systemsFactory));
			systems.Add(new UIFeature(systemsFactory));
		}
	}
}