namespace Asteroids.Scripts.DI.Container
{
	public interface IContainer
	{
		TBinding Resolve<TBinding>();
	}
}