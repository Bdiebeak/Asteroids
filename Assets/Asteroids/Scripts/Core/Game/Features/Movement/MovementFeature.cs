using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Systems;
using Asteroids.Scripts.Core.Infrastructure.Services.Time;
using Asteroids.Scripts.ECS.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Movement
{
	public class MovementFeature : Feature
	{
		private readonly InputContext _inputContext;
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;

		public MovementFeature(InputContext inputContext, GameplayContext gameplayContext, ITimeService timeService)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_timeService = timeService;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(new ApplyMoveInputSystem(_inputContext, _gameplayContext, _timeService));
			systems.Add(new VelocityDragSystem(_gameplayContext, _timeService));
			systems.Add(new MoveSystem(_gameplayContext, _timeService));
			systems.Add(new RotateSystem(_gameplayContext, _timeService));
		}
	}
}