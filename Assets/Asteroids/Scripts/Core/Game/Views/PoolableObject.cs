using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.Scripts.Core.Game.Views
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

		public void OnGet(Vector2 position, Quaternion rotation, Transform parent = null)
		{
			transform.position = position;
			transform.rotation = rotation;
			transform.parent = parent;
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