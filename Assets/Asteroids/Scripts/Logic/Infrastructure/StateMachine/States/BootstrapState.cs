namespace Asteroids.Scripts.Logic.Infrastructure.StateMachine.States
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
			// TODO: show greetings screen.
			_stateMachine.Enter<GameInitializeState>();
		}

		public void Update() { }

		public void Exit() { }
	}
}