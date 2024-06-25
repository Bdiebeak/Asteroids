using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Converters.Base
{
	public static class ConverterExtensions
	{
		public static Entity ConvertContainer(this IContext context, IConvertersContainer container)
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