using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Components;
using Asteroids.Scripts.Core.Utilities.Services.Camera;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.WorldBounds.Systems
{
	public class DetectOutOfBoundsSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ICameraProvider _cameraProvider;
		private readonly Mask _mask;

		public DetectOutOfBoundsSystem(GameplayContext gameplayContext, ICameraProvider cameraProvider)
		{
			_gameplayContext = gameplayContext;
			_cameraProvider = cameraProvider;
			_mask = new Mask().Include<Position>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				Bounds bounds = _cameraProvider.Bounds;
				Vector3 position = entity.Get<Position>().value;
				position.z = bounds.center.z; // Cause Bounds.Contains works with a 3d space.
				if (bounds.Contains(position))
				{
					if (entity.Has<OutOfBoundsMarker>() == false)
					{
						continue;
					}
					entity.Remove<OutOfBoundsMarker>();
				}
				else
				{
					if (entity.Has<OutOfBoundsMarker>())
					{
						continue;
					}
					entity.Add(new OutOfBoundsMarker());
				}
			}
		}
	}
}