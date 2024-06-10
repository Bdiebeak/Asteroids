namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public interface IState
	{
		void Enter();
		void Update();
		void Exit();
	}
}