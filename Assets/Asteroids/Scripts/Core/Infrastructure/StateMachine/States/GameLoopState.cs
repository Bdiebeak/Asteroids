using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class GameLoopState : IState
	{
		private readonly IGameStateMachine _stateMachine;
		private readonly EcsStartup _ecsStartup;

		public GameLoopState(IGameStateMachine stateMachine, EcsStartup ecsStartup)
		{
			_stateMachine = stateMachine;
			_ecsStartup = ecsStartup;
		}

		public void Enter()
		{
			_ecsStartup.Start();
		}

		public void Update()
		{
			_ecsStartup.Update(Time.deltaTime);
			_ecsStartup.CleanUp();
		}

		public void Exit()
		{
			_ecsStartup.Stop();
		}
	}
}