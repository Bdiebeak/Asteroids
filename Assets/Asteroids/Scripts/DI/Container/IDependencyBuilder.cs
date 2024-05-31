namespace Asteroids.Scripts.DI.Container
{
	public interface IDependencyBuilder
	{
		DependencyInfo Register<TBinding>(BindType bindType = BindType.Singleton);
		void Build();
	}
}