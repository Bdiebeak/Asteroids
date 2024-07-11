using Asteroids.Scripts.Core.Game.Views;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Features.Destroy.Listeners
{
	public class DestroyListener : EcsListener
	{
		private Entity _entity;

		public override void Construct(Entity entity)
		{
			_entity = entity;
			_entity.Destroyed += OnEntityDestroyed;
		}

		private void OnDestroy()
		{
			_entity.Destroyed -= OnEntityDestroyed;
		}

		private void OnEntityDestroyed()
		{
			_entity.Destroyed -= OnEntityDestroyed;
			if (TryGetComponent(out PoolableObject poolable))
			{
				poolable.Release();
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}