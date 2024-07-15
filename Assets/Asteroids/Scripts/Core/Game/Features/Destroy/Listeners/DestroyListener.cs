using Asteroids.Scripts.Core.Game.Behaviours;
using Asteroids.Scripts.Core.Utilities.Pool;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Features.Destroy.Listeners
{
	public class DestroyListener : EcsListener
	{
		private PoolableObject _poolable;
		private Entity _entity;

		public override void StartListen(Entity entity)
		{
			_entity = entity;
			_entity.Destroyed += OnEntityDestroyed;
		}

		private void Awake()
		{
			_poolable = GetComponent<PoolableObject>();
		}

		private void OnDestroy()
		{
			_entity.Destroyed -= OnEntityDestroyed;
		}

		private void OnEntityDestroyed()
		{
			_entity.Destroyed -= OnEntityDestroyed;
			if (_poolable)
			{
				_poolable.Release();
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}