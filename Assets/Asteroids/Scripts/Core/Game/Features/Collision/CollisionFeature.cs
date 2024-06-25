using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Base;
using Asteroids.Scripts.Core.Game.Features.Collision.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Collision
{
	public class CollisionFeature : Feature
	{
		public CollisionFeature(ISystemsFactory systemsFactory) : base(systemsFactory) { }

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(systemsFactory.CreateSystem<PlayerCollisionSystem>());
			systems.Add(systemsFactory.CreateSystem<BulletCollisonSystem>());
			systems.Add(systemsFactory.CreateSystem<CleanUpCollisionEventsSystem>());
		}
	}
}