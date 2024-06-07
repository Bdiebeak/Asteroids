using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Extensions;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using Asteroids.Scripts.Logic.Components;
using Asteroids.Scripts.Logic.Infrastructure.Configs;
using Asteroids.Scripts.Logic.Infrastructure.Services;

namespace Asteroids.Scripts.Logic.Systems
{
	public class InitializePlayerSystem : IStartSystem
	{
		private readonly IContext _gameplayContext;
		private readonly IViewFactory _viewFactory;

		public InitializePlayerSystem(IContext gameplayContext, IViewFactory viewFactory)
		{
			_gameplayContext = gameplayContext;
			_viewFactory = viewFactory;
		}

		public void Start()
		{
			Entity entity = _gameplayContext.CreateEntity();
			entity.Add<PlayerComponent>();
			entity.Add<ViewComponent>().value = _viewFactory.CreatePlayerView();
			// TODO: entity.ConfigureWithMovement();
			entity.Add<PositionComponent>();
			entity.Add<MoveDirectionComponent>();
			entity.Add<MoveSpeedComponent>().value = GameConfig.ShipMoveSpeed;
			// TODO: entity.ConfigureWithRotation();
			entity.Add<RotationComponent>();
			entity.Add<AngularDirectionComponent>();
			entity.Add<AngularSpeedComponent>().value = GameConfig.ShipAngularSpeed;
		}
	}
}