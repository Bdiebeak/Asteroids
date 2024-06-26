using Asteroids.Scripts.Core.Game.Converters;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Views
{
	public class TransformUpdaterConverter : MonoConverter
	{
		protected override void OnConvert(IContext context, Entity entity)
		{
			TransformUpdater transformUpdater = gameObject.AddComponent<TransformUpdater>();
			transformUpdater.Initialize(entity);
		}
	}
}