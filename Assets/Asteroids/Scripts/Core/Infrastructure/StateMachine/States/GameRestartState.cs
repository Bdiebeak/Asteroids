namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class GameRestartState : IState
	{
		private IGameStateMachine _stateMachine;

		public GameRestartState(IGameStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}

		public void Enter()
		{
			_stateMachine.Enter<GameInitializeState>();
		}

		public void Update() { }

		public void Exit() { }
	}
}