using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Converters.Base
{
	public interface IConverter
	{
		void Convert(IContext context, Entity entity);
	}
}