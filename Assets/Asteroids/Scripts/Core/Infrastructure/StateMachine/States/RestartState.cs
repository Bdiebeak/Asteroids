namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class RestartState : BaseState
	{
		private readonly IGameStateMachine _stateMachine;

		public RestartState(IGameStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}

		public override void Enter()
		{
			_stateMachine.Enter<GameLoopState>();
		}
	}
}