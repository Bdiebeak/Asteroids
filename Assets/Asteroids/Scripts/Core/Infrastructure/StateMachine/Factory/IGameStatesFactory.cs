namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.Factory
{
	public interface IGameStatesFactory
	{
		TState GetState<TState>();
	}
}