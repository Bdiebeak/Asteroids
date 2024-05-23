using UnityEngine;

namespace Asteroids.Scripts.Logic.Infrastructure.StateMachine.States
{
	public class GameLoopState : IState
	{
		private IGameStateMachine _stateMachine;

		public GameLoopState(IGameStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}

		public void Enter()
		{
			Debug.Log("Enter game loop state");
		}

		public void Update()
		{
			Debug.Log("Update game loop state");
			if (Input.GetKeyDown(KeyCode.R))
			{
				_stateMachine.Enter<GameRestartState>();
			}
		}

		public void Exit()
		{
			Debug.Log("Exit game loop state");
		}
	}
}