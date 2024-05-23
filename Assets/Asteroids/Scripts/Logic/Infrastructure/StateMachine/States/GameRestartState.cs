using UnityEngine;

namespace Asteroids.Scripts.Logic.Infrastructure.StateMachine.States
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
			Debug.Log("Enter game restart state");
			_stateMachine.Enter<GameInitializeState>();
		}

		public void Update()
		{
			Debug.Log("Update game restart state");
		}

		public void Exit()
		{
			Debug.Log("Exit game restart state");
		}
	}
}