using Asteroids.Scripts.Core.Gameplay.Input.Systems;
using Asteroids.Scripts.Core.Infrastructure.Services.Input;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Gameplay.Input
{
	public class InputFeature : Feature
	{
		private readonly IContext _inputContext;
		private readonly IContext _gameplayContext;
		private readonly IInputService _inputService;

		public InputFeature(IContext inputContext, IContext gameplayContext, IInputService inputService)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_inputService = inputService;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(new InitializeInputSystem(_inputContext))
				   .Add(new UpdateMoveInputSystem(_inputContext, _inputService))
				   .Add(new UpdateAttackInputSystem(_inputContext, _inputService))
				   .Add(new ApplyMoveInputSystem(_inputContext, _gameplayContext))
				   .Add(new ApplyAttackInputSystem(_inputContext, _gameplayContext));
		}
	}
}