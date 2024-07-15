using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Collision.Events;
using Asteroids.Scripts.ECS.Events;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Collision.Systems
{
	public class CleanUpCollisionEventsSystem : ICleanUpSystem
	{
		private readonly GameplayContext _gameplayContext;

		public CleanUpCollisionEventsSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
		}

		public void CleanUp()
		{
			_gameplayContext.DestroyEvents<CollisionEnterEvent>();
		}
	}
}