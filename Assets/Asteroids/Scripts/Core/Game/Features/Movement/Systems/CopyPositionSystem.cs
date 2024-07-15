using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Systems
{
	public class CopyPositionSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _copyTargetMask;

		public CopyPositionSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_copyTargetMask = new Mask().Include<CopyTargetPositionComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_copyTargetMask);
			foreach (Entity entity in entities)
			{
				CopyTargetPositionComponent copyTargetPosition = entity.Get<CopyTargetPositionComponent>();
				if (_gameplayContext.TryGetEntity(copyTargetPosition.targetEntityId, out Entity target) == false)
				{
					Debug.LogError("Can't get entity to copy position.");
					continue;
				}

				PositionComponent position = entity.Get<PositionComponent>();
				PositionComponent targetPosition = target.Get<PositionComponent>();
				position.value = targetPosition.value;
			}
		}
	}
}