using Asteroids.Scripts.Core.Gameplay.Movement.Components;
using Asteroids.Scripts.Core.Gameplay.Player.Components;
using Asteroids.Scripts.Core.Gameplay.View;
using Asteroids.Scripts.Core.Gameplay.View.Components;
using Asteroids.Scripts.Core.Infrastructure.Configs;
using Asteroids.Scripts.Core.Infrastructure.Factories;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Gameplay.Player.Systems
{
	public class InitializePlayerSystem : IStartSystem
	{
		private readonly IContext _gameplayContext;
		private readonly IGameFactory _gameFactory;

		public InitializePlayerSystem(IContext gameplayContext, IGameFactory gameFactory)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
		}

		public void Start()
		{
			IView playerView = _gameFactory.CreatePlayerView();

			Entity entity = _gameplayContext.CreateEntity();
			entity.Add<PlayerComponent>(new PlayerComponent());
			entity.Add<ViewComponent>(new ViewComponent()).value = playerView;
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