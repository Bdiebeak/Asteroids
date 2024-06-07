using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Extensions;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using Asteroids.Scripts.Logic.Components;

namespace Asteroids.Scripts.Logic.Systems
{
	public class UpdateViewSystem : IUpdateSystem
	{
		private readonly IContext _gameplayContext;
		private readonly Filter _viewFilter;

		public UpdateViewSystem(IContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_viewFilter = new Filter().Include<ViewComponent>();
		}

		public void Update(float deltaTime)
		{
			var viewEntities = _gameplayContext.GetEntities(_viewFilter);
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