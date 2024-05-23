using UnityEngine;

namespace Asteroids.Scripts.Logic.Infrastructure.StateMachine.States
{
	public class BootstrapState : IState
	{
		private IGameStateMachine _stateMachine;

		public BootstrapState(IGameStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}

		public void Enter()
		{
			Debug.Log("Enter bootstrap state");
			_stateMachine.Enter<GameInitializeState>();
		}

		public void Update()
		{
			Debug.Log("Update bootstrap state");
		}

		public void Exit()
		{
			Debug.Log("Exit bootstrap state");
		}
	}
}