using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.ECS.Converters
{
	public static class EntityConverter
	{
		public static Entity ConvertContainer(this IContext context, IComponentsContainer container)
		{
			Entity entity = context.CreateEntity();
			foreach (IConverter converter in container.Converters)
			{
				converter.Convert(context, entity);
			}
			return entity;
		}
	}
}