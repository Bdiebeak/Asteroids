namespace Asteroids.Scripts.Core.Infrastructure.StateMachine
{
	public interface IGameStatesFactory
	{
		TState GetState<TState>();
	}
}