using Asteroids.Scripts.ECS.Contexts;

namespace Asteroids.Scripts.Core.Infrastructure.Services
{
	public interface IEcsDebugger
	{
		void SetContexts(params IContext[] contexts);
	}
}