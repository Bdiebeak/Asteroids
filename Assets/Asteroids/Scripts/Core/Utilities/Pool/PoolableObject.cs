using UnityEngine;

namespace Asteroids.Scripts.Core.Utilities.Pool
{
	public class PoolableObject : MonoBehaviour
	{
		private IPool _pool;

		public void Initialize(IPool pool)
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