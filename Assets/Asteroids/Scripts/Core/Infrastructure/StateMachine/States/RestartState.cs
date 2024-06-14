namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class RestartState : IState
	{
		private IGameStateMachine _stateMachine;

		public RestartState(IGameStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}

		public void Enter()
		{
			_stateMachine.Enter<GameLoopState>();
		}

		public void Update() { }
		public void Exit() { }
	}
}