using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Wrapper.Components;
using Asteroids.Scripts.Core.Infrastructure.Services.Configs;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Wrapper.Systems
{
	public class KeepInScreenSystem : IStartSystem, IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Camera _mainCamera;
		private readonly Mask _mask;
		private Bounds _bounds; // TODO: don't cache it in system.

		public KeepInScreenSystem(GameplayContext gameplayContext, Camera mainCamera)
		{
			_gameplayContext = gameplayContext;
			_mainCamera = mainCamera;
			_mask = new Mask().Include<KeepInScreenComponent>();
		}

		public void Start()
		{
			float screenAspect = Screen.width / (float)Screen.height;
			float cameraHeight = (_mainCamera.orthographicSize + GameConfig.ScreenBorderOffset) * 2;
			_bounds = new Bounds(_mainCamera.transform.position,
								 new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				PositionComponent position = entity.Get<PositionComponent>();
				if (position.value.x < _bounds.min.x)
				{
					position.value.x = _bounds.max.x;
				}
				else if (position.value.x > _bounds.max.x)
				{
					position.value.x = _bounds.min.x;
				}

				if (position.value.y < _bounds.min.y)
				{
					position.value.y = _bounds.max.y;
				}
				else if (position.value.y > _bounds.max.y)
				{
					position.value.y = _bounds.min.y;
				}
				// TODO: request change position
			}
		}
	}
}