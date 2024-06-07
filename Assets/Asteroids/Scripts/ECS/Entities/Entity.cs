using Asteroids.Scripts.ECS.Contexts;

namespace Asteroids.Scripts.ECS.Entities
{
	public class Entity
	{
		public int Id { get; private set; }
		public IContext Context { get; private set; }

		public Entity(int id, IContext context)
		{
			Id = id;
			Context = context;
		}
	}
}