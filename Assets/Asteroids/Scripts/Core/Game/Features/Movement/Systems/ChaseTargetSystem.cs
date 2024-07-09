using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Systems
{
	public class ChaseTargetSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _chaseTargetMask;

		public ChaseTargetSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_chaseTargetMask = new Mask().Include<ChaseTarget>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_chaseTargetMask);
			foreach (Entity entity in entities)
			{
				Entity target = entity.Get<ChaseTarget>().value;
				if (_gameplayContext.IsActive(target) == false)
				{
					Debug.LogError("Can't follow entity, it isn't active.");
					continue;
				}

				Position position = entity.Get<Position>();
				Position targetPosition = target.Get<Position>();
				MoveDirection moveDirection = entity.Get<MoveDirection>();
				moveDirection.value = (targetPosition.value - position.value).normalized;
			}
		}
	}
}