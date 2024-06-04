using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.ECS.Systems.Container
{
	public interface ISystemsContainer
	{
		ISystemsContainer Add(ISystem system);
		void Start();
		void Update(float deltaTime);
		void CleanUp();
		void Stop();
	}
}