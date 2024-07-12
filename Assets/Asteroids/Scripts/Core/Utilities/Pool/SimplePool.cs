using System;
using System.Collections.Generic;

namespace Asteroids.Scripts.Core.Utilities.Pool
{
	public class SimplePool : IPool
	{
		private readonly Queue<PoolableObject> _pool = new();
		private readonly HashSet<PoolableObject> _allObjects = new();
		private readonly Func<PoolableObject> _creationFunc;

		public SimplePool(Func<PoolableObject> creationFunc)
		{
			_creationFunc = creationFunc;
		}

		public PoolableObject Get()
		{
			PoolableObject poolable;
			if (_pool.Count == 0)
			{
				poolable = _creationFunc.Invoke();
				_allObjects.Add(poolable);
			}
			else
			{
				poolable = _pool.Dequeue();
			}

			poolable.OnGet();
			return poolable;
		}

		public void Release(PoolableObject poolable)
		{
			poolable.OnRelease();
			_pool.Enqueue(poolable);
		}

		public void Clean()
		{
			foreach (PoolableObject poolable in _allObjects)
			{
				poolable.OnDestroy();
			}
			_pool.Clear();
			_allObjects.Clear();
		}
	}
}