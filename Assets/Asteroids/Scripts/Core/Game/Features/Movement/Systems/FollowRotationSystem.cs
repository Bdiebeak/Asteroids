using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Systems
{
	public class FollowRotationSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _mask;

		public FollowRotationSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_mask = new Mask().Include<FollowRotationComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				FollowRotationComponent followRotation = entity.Get<FollowRotationComponent>();
				RotationComponent rotation = entity.Get<RotationComponent>();
				RotationComponent targetRotation = followRotation.target.Get<RotationComponent>();
				rotation.value = targetRotation.value;
			}
		}
	}
}