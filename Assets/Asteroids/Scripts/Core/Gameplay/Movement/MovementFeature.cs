using Asteroids.Scripts.Core.Gameplay.Movement.Systems;
using Asteroids.Scripts.Core.Infrastructure.Services.Time;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Gameplay.Movement
{
	public class MovementFeature : Feature
	{
		private readonly IContext _inputContext;
		private readonly IContext _gameplayContext;
		private readonly ITimeService _timeService;

		public MovementFeature(IContext inputContext, IContext gameplayContext, ITimeService timeService)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_timeService = timeService;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(new ApplyMoveInputSystem(_inputContext, _gameplayContext, _timeService))
				   .Add(new VelocityDragSystem(_gameplayContext, _timeService))
				   .Add(new MoveSystem(_gameplayContext, _timeService))
				   .Add(new RotateSystem(_gameplayContext, _timeService));
		}
	}
}