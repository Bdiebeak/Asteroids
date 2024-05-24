namespace Asteroids.Scripts.DI
{
	public interface IServiceProvider
	{
		void Bind<TService>(TService implementation);
		TService Resolve<TService>();
	}
}