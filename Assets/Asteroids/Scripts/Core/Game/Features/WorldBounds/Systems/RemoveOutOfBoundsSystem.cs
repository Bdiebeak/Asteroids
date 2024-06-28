using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Components;
using Asteroids.Scripts.Core.Utilities.Extensions;
using Asteroids.Scripts.Core.Utilities.Services.Camera;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.WorldBounds.Systems
{
	public class RemoveOutOfBoundsSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ICameraProvider _cameraProvider;
		private readonly Mask _movableMask;

		public RemoveOutOfBoundsSystem(GameplayContext gameplayContext, ICameraProvider cameraProvider)
		{
			_gameplayContext = gameplayContext;
			_cameraProvider = cameraProvider;
			_movableMask = new Mask().Include<Position>()
									 .Include<OutOfBoundsMarker>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_movableMask);
			foreach (Entity entity in entities)
			{
				Bounds bounds = _cameraProvider.Bounds;
				Position position = entity.Get<Position>();
				if (bounds.IsInBounds(position.value) == false)
				{
					continue;
				}
				entity.Remove<OutOfBoundsMarker>();
			}
		}
	}
}