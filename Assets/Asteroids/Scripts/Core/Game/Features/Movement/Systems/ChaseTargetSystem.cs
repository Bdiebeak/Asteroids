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
		private readonly Mask _mask;

		public ChaseTargetSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_mask = new Mask().Include<ChaseTarget>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				ChaseTarget chaseTarget = entity.Get<ChaseTarget>();
				Entity target = chaseTarget.target;
				if (_gameplayContext.IsActive(target) == false)
				{
					Debug.LogError("Can't follow entity, it isn't active.");
					continue;
				}

				Position position = entity.Get<Position>();
				Position targetPosition = target.Get<Position>();
				Velocity velocity = entity.Get<Velocity>();
				// TODO: don't like magnitude here - better to use MoveDirection and Speed
				velocity.value = (targetPosition.value - position.value).normalized * velocity.value.magnitude;
			}
		}
	}
}