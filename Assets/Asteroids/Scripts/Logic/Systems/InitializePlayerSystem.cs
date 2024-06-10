using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
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
			entity.Add<PlayerComponent>(new PlayerComponent());
			entity.Add<ViewComponent>(new ViewComponent()).value = _viewFactory.CreatePlayerView();
			// TODO: entity.ConfigureWithMovement();
			entity.Add<PositionComponent>(new PositionComponent());
			entity.Add<MoveDirectionComponent>(new MoveDirectionComponent());
			entity.Add<MoveSpeedComponent>(new MoveSpeedComponent()).value = GameConfig.ShipMoveSpeed;
			// TODO: entity.ConfigureWithRotation();
			entity.Add<RotationComponent>(new RotationComponent());
			entity.Add<AngularDirectionComponent>(new AngularDirectionComponent());
			entity.Add<AngularSpeedComponent>(new AngularSpeedComponent()).value = GameConfig.ShipAngularSpeed;
		}
	}
}