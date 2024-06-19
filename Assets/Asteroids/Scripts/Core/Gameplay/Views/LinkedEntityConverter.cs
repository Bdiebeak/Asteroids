using Asteroids.Scripts.Core.Gameplay.Converters;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Gameplay.Views
{
	public class LinkedEntityConverter : MonoConverter
	{
		protected override void OnConvert(IContext context, Entity entity)
		{
			if (gameObject.TryGetComponent(out LinkedEntity linkedEntity) == false)
			{
				linkedEntity = gameObject.AddComponent<LinkedEntity>();
			}
			linkedEntity.Initialize(entity);
		}
	}
}