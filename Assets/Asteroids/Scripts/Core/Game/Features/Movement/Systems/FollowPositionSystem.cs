using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Systems
{
	public class FollowPositionSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _mask;

		public FollowPositionSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_mask = new Mask().Include<FollowPositionComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				FollowPositionComponent followPosition = entity.Get<FollowPositionComponent>();
				PositionComponent position = entity.Get<PositionComponent>();
				PositionComponent targetPosition = followPosition.target.Get<PositionComponent>();
				position.value = targetPosition.value;
			}
		}
	}
}