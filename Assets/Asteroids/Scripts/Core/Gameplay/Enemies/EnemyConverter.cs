using Asteroids.Scripts.Core.Gameplay.Converters;
using Asteroids.Scripts.Core.Gameplay.Enemies.Components;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Gameplay.Enemies
{
	public class EnemyConverter : MonoConverter
	{
		protected override void OnConvert(IContext context, Entity entity)
		{
			entity.Add(new EnemyComponent());
		}
	}
}