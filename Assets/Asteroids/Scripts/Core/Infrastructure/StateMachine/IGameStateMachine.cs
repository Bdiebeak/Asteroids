using Asteroids.Scripts.Core.Infrastructure.StateMachine.States;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine
{
	public interface IGameStateMachine
	{
		BaseState CurrentState { get; }
		void Register<TState>(TState state) where TState : BaseState;
		void Enter<TState>() where TState : BaseState;
		void Update();
		void Exit();
	}
}