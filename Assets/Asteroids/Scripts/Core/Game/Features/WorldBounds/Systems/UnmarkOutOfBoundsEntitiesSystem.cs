﻿using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Components;
using Asteroids.Scripts.Core.Utilities.Extensions;
using Asteroids.Scripts.Core.Utilities.Services.GameCamera;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.WorldBounds.Systems
{
	public class UnmarkOutOfBoundsEntitiesSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ICameraService _cameraService;
		private readonly Mask _movableMask;

		public UnmarkOutOfBoundsEntitiesSystem(GameplayContext gameplayContext, ICameraService cameraService)
		{
			_gameplayContext = gameplayContext;
			_cameraService = cameraService;
			_movableMask = new Mask().Include<PositionComponent>()
									 .Include<OutOfBoundsComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_movableMask);
			foreach (Entity entity in entities)
			{
				PositionComponent position = entity.Get<PositionComponent>();
				if (_cameraService.Bounds.IsInBounds(position.value) == false)
				{
					continue;
				}
				entity.Remove<OutOfBoundsComponent>();
			}
		}
	}
}