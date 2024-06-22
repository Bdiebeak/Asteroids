using Asteroids.Scripts.Core.Infrastructure.Services.Camera;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class BootstrapState : IState
	{
		private readonly IGameStateMachine _stateMachine;
		private readonly ICameraProvider _cameraProvider;

		public BootstrapState(IGameStateMachine stateMachine, ICameraProvider cameraProvider)
		{
			_stateMachine = stateMachine;
			_cameraProvider = cameraProvider;
		}

		public void Enter()
		{
			_cameraProvider.Initialize();
			_stateMachine.Enter<GameStartState>();
		}

		public void Update() { }
		public void Exit() { }
	}
}