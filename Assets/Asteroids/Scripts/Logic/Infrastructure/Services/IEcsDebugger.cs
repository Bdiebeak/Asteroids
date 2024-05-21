using Asteroids.Scripts.ECS.Contexts;

namespace Asteroids.Scripts.Logic.Infrastructure.Services
{
	public interface IEcsDebugger
	{
		void SetContexts(params IContext[] contexts);
	}
}