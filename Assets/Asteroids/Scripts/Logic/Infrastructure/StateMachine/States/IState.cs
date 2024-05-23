namespace Asteroids.Scripts.Logic.Infrastructure.StateMachine.States
{
	public interface IState
	{
		void Enter();
		void Update();
		void Exit();
	}
}