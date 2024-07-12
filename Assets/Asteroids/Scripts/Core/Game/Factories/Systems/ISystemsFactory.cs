namespace Asteroids.Scripts.Core.Game.Factories.Systems
{
	public interface ISystemsFactory
	{
		TSystem CreateSystem<TSystem>();
	}
}