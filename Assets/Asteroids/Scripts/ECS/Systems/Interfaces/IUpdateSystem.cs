namespace Asteroids.Scripts.ECS.Systems.Interfaces
{
	public interface IUpdateSystem : ISystem
	{
		void Update(float deltaTime);
	}
}