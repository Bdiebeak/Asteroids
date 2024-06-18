using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.ECS.Converters
{
	public interface IConverter
	{
		void Convert(IContext context, Entity entity);
	}
}