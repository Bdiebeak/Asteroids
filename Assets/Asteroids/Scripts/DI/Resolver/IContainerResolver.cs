namespace Asteroids.Scripts.DI.Resolver
{
	public interface IContainerResolver
	{
		TBinding Resolve<TBinding>();
	}
}