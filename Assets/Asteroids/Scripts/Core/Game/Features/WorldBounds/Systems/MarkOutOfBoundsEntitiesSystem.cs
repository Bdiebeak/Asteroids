using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Components;
using Asteroids.Scripts.Core.Utilities.Extensions;
using Asteroids.Scripts.Core.Utilities.Services.GameCamera;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.WorldBounds.Systems
{
	public class MarkOutOfBoundsEntitiesSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ICameraService _cameraService;
		private readonly Mask _movableMask;

		public MarkOutOfBoundsEntitiesSystem(GameplayContext gameplayContext, ICameraService cameraService)
		{
			_gameplayContext = gameplayContext;
			_cameraService = cameraService;
			_movableMask = new Mask().Include<PositionComponent>()
									 .Exclude<OutOfBoundsComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_movableMask);
			foreach (Entity entity in entities)
			{
				Bounds bounds = _cameraService.Bounds;
				PositionComponent position = entity.Get<PositionComponent>();
				if (bounds.IsInBounds(position.value))
				{
					continue;
				}
				entity.Add(new OutOfBoundsComponent());
			}
		}
	}
}