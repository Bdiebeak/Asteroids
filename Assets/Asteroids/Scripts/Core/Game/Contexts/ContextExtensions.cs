using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Contexts
{
	public static class ContextExtensions
	{
		public static bool AreEntitiesAlive(this IContext context, params Entity[] entities)
		{
			foreach (Entity entity in entities)
			{
				if (context.IsActive(entity) == false)
				{
					return false;
				}
			}
			return true;
		}
	}
}