namespace Asteroids.Scripts.ECS.Contexts.Container
{
	public interface IContextsContainer
	{
		void Add(string key, IContext context);
		IContext Get(string key);
	}
}