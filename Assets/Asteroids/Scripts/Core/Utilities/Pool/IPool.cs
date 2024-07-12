namespace Asteroids.Scripts.Core.Utilities.Pool
{
	public interface IPool
	{
		PoolableObject Get();
		void Release(PoolableObject poolable);
		void Clean();
	}
}