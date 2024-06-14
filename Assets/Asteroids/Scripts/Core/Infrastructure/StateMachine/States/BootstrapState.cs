namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class BootstrapState : IState
	{
		private readonly IGameStateMachine _stateMachine;

		public BootstrapState(IGameStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}

		public void Enter()
		{
			_stateMachine.Enter<GameStartState>();
		}

		public void Update() { }
		public void Exit() { }
	}
}