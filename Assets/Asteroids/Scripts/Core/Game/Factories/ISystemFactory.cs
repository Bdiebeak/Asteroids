namespace Asteroids.Scripts.Core.Game.Factories
{
	public interface ISystemFactory
	{
		TSystem CreateSystem<TSystem>();
	}
}