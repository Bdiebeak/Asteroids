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
		private readonly Mask _mask;

		public CopyRotationSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_mask = new Mask().Include<CopyTargetRotation>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				Entity target = entity.Get<CopyTargetRotation>().target;
				if (_gameplayContext.IsActive(target) == false)
				{
					Debug.LogError("Target entity isn't active. Can't follow it's rotation.");
					continue;
				}

				Rotation rotation = entity.Get<Rotation>();
				Rotation targetRotation = target.Get<Rotation>();
				rotation.value = targetRotation.value;
			}
		}
	}
}