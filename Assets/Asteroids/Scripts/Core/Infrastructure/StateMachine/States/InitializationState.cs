using Asteroids.Scripts.Core.Gameplay;
using Asteroids.Scripts.Core.Infrastructure.Factories;
using Asteroids.Scripts.Core.Infrastructure.Services.Input;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class InitializationState : IState
	{
		private readonly IGameStateMachine _stateMachine;
		private readonly EcsStartup _ecsStartup;
		private readonly IInputService _inputService;
		private readonly IViewFactory _viewFactory;

		public InitializationState(IGameStateMachine stateMachine, EcsStartup ecsStartup,
								   IInputService inputService, IViewFactory viewFactory)
		{
			_stateMachine = stateMachine;
			_ecsStartup = ecsStartup;
			_inputService = inputService;
			_viewFactory = viewFactory;
		}

		public void Enter()
		{
			_ecsStartup.Initialize(_inputService, _viewFactory);
			_stateMachine.Enter<GameLoopState>();
		}

		public void Update()
		{
		}

		public void Exit()
		{
		}
	}
}