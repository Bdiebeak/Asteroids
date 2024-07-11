using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.Scripts.Core.Game.Behaviours
{
	public class PoolableObject : MonoBehaviour
	{
		private IObjectPool<PoolableObject> _pool;

		public void Initialize(IObjectPool<PoolableObject> pool)
		{
			_pool = pool;
		}

		public void Release()
		{
			_pool.Release(this);
		}

		public void OnGet()
		{
			gameObject.SetActive(true);
		}

		public void OnRelease()
		{
			gameObject.SetActive(false);
		}

		public void OnDestroy()
		{
			Destroy(gameObject);
		}
	}
}