namespace Asteroids.Scripts.Core.Game.Factories
{
	public interface ISystemsFactory
	{
		TSystem CreateSystem<TSystem>();
	}
}