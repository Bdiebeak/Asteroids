using System.Collections.Generic;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.ECS.Components
{
	public class Pool<TObject> : IPool
	{
		private HashSet<Entity> _entities = new();

		public IReadOnlyCollection<Entity> Entities => _entities;

		public TObject Add(int entityId)
		{
			throw new System.NotImplementedException();
		}

		public void Remove(int entityId)
		{
			throw new System.NotImplementedException();
		}

		public TObject Get(int entityId)
		{
			throw new System.NotImplementedException();
		}

		public bool Has(int entityId)
		{
			throw new System.NotImplementedException();
		}

		public int GetActiveCount()
		{
			throw new System.NotImplementedException();
		}

		public int GetPooledCount()
		{
			throw new System.NotImplementedException();
		}
	}
}