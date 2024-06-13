using Asteroids.Scripts.Core.Infrastructure.StateMachine;
using Asteroids.Scripts.Core.Infrastructure.StateMachine.States;

namespace Asteroids.Scripts.Core.Infrastructure.Installers
{
	public class GameOverState : IState
	{
		private readonly IGameStateMachine _stateMachine;

		public GameOverState(IGameStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}

		public void Enter()
		{
			// TODO: show game over screen with score.
		}

		public void Update()
		{
		}

		public void Exit()
		{
			// TODO: hide game over screen with score.
		}
	}
}