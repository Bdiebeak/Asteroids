using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Requests;
using Asteroids.Scripts.Core.Game.Features.Requests;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Components;
using Asteroids.Scripts.Core.Utilities.Services.Camera;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.WorldBounds.Systems
{
	public class KeepInBoundsSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ICameraProvider _cameraProvider;
		private readonly Mask _keepInBoundsMask;

		public KeepInBoundsSystem(GameplayContext gameplayContext, ICameraProvider cameraProvider)
		{
			_gameplayContext = gameplayContext;
			_cameraProvider = cameraProvider;
			_keepInBoundsMask = new Mask().Include<KeepInBoundsMarker>()
							  .Include<OutOfBoundsMarker>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_keepInBoundsMask);
			foreach (Entity entity in entities)
			{
				Vector2 position = entity.Get<Position>().value;
				if (position.x < _cameraProvider.Bounds.min.x)
				{
					position.x = _cameraProvider.Bounds.max.x;
				}
				else if (position.x > _cameraProvider.Bounds.max.x)
				{
					position.x = _cameraProvider.Bounds.min.x;
				}

				if (position.y < _cameraProvider.Bounds.min.y)
				{
					position.y = _cameraProvider.Bounds.max.y;
				}
				else if (position.y > _cameraProvider.Bounds.max.y)
				{
					position.y = _cameraProvider.Bounds.min.y;
				}

				_gameplayContext.CreateRequest(new TeleportRequest
				{
					target = entity,
					position = position
				});
			}
		}
	}
}