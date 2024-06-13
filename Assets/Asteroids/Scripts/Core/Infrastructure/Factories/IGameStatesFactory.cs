namespace Asteroids.Scripts.Core.Infrastructure.Factories
{
	public interface IGameStatesFactory
	{
		TState GetState<TState>();
	}
}