﻿using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Requests;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Components;
using Asteroids.Scripts.Core.Utilities.Extensions;
using Asteroids.Scripts.Core.Utilities.Services.GameCamera;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.WorldBounds.Systems
{
	public class KeepInBoundsSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ICameraService _cameraService;
		private readonly Mask _keepInBoundsMask;

		public KeepInBoundsSystem(GameplayContext gameplayContext, ICameraService cameraService)
		{
			_gameplayContext = gameplayContext;
			_cameraService = cameraService;
			_keepInBoundsMask = new Mask().Include<KeepInBoundsComponent>()
										  .Include<OutOfBoundsComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_keepInBoundsMask);
			foreach (Entity entity in entities)
			{
				PositionComponent position = entity.Get<PositionComponent>();
				Vector2 newPosition = _cameraService.Bounds.GetOppositeEdgePosition(position.value);
				_gameplayContext.CreateRequest(new TeleportRequest
				{
					targetEntityId = entity.Id,
					position = newPosition
				});
			}
		}
	}
}