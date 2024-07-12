using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Systems
{
	public class CopyRotationSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _copyTargetMask;

		public CopyRotationSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_copyTargetMask = new Mask().Include<CopyTargetRotationComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_copyTargetMask);
			foreach (Entity entity in entities)
			{
				Entity target = entity.Get<CopyTargetRotationComponent>().target;
				if (_gameplayContext.IsActive(target) == false)
				{
					Debug.LogError("Target entity isn't active. Can't follow it's rotation.");
					continue;
				}

				RotationComponent rotation = entity.Get<RotationComponent>();
				RotationComponent targetRotation = target.Get<RotationComponent>();
				rotation.value = targetRotation.value;
			}
		}
	}
}