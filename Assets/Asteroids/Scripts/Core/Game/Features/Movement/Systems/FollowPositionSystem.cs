using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Systems
{
	public class FollowPositionSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _mask;

		public FollowPositionSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_mask = new Mask().Include<FollowPosition>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				FollowPosition followPosition = entity.Get<FollowPosition>();
				Entity target = followPosition.target;
				if (_gameplayContext.IsActive(target) == false)
				{
					Debug.LogError("Target entity isn't active. Can't follow it's position.");
					continue;
				}

				Position position = entity.Get<Position>();
				Position targetPosition = target.Get<Position>();
				position.value = targetPosition.value;
			}
		}
	}
}