using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.KeepInScreen.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Utilities.Services.Camera;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.KeepInScreen.Systems
{
	public class KeepInScreenSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ICameraProvider _cameraProvider;
		private readonly Mask _mask;

		public KeepInScreenSystem(GameplayContext gameplayContext, ICameraProvider cameraProvider)
		{
			_gameplayContext = gameplayContext;
			_cameraProvider = cameraProvider;
			_mask = new Mask().Include<KeepInScreenComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				PositionComponent position = entity.Get<PositionComponent>();
				if (position.value.x < _cameraProvider.Bounds.min.x)
				{
					position.value.x = _cameraProvider.Bounds.max.x;
				}
				else if (position.value.x > _cameraProvider.Bounds.max.x)
				{
					position.value.x = _cameraProvider.Bounds.min.x;
				}

				if (position.value.y < _cameraProvider.Bounds.min.y)
				{
					position.value.y = _cameraProvider.Bounds.max.y;
				}
				else if (position.value.y > _cameraProvider.Bounds.max.y)
				{
					position.value.y = _cameraProvider.Bounds.min.y;
				}
				// TODO: request change position
			}
		}
	}
}