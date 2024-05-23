using UnityEngine;

namespace Asteroids.Scripts.Logic.Infrastructure.StateMachine.States
{
	public class GameInitializeState : IState
	{
		private IGameStateMachine _stateMachine;

		public GameInitializeState(IGameStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}

		public void Enter()
		{
			Debug.Log("Enter game init state");
			_stateMachine.Enter<GameLoopState>();
		}

		public void Update()
		{
			Debug.Log("Update game init state");
		}

		public void Exit()
		{
			Debug.Log("Exit game init state");
		}
	}
}