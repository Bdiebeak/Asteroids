using Asteroids.Scripts.Core.Gameplay.Movement.Components;
using Asteroids.Scripts.Core.Gameplay.View.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Gameplay.View.Systems
{
	public class UpdateViewSystem : IUpdateSystem
	{
		private readonly IContext _gameplayContext;
		private readonly Mask _viewMask;

		public UpdateViewSystem(IContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_viewMask = new Mask().Include<ViewComponent>();
		}

		public void Update()
		{
			var viewEntities = _gameplayContext.GetEntities(_viewMask);
			foreach (Entity entity in viewEntities)
			{
				ViewComponent view = entity.Get<ViewComponent>();

				if (entity.Has<PositionComponent>())
				{
					view.value.SetPosition(entity.Get<PositionComponent>().value);
				}
				if (entity.Has<RotationComponent>())
				{
					view.value.SetRotation(entity.Get<RotationComponent>().value);
				}
			}
		}
	}
}