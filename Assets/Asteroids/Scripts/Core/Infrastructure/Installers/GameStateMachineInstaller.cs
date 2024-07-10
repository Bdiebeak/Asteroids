using Asteroids.Scripts.Core.Infrastructure.StateMachine;
using Asteroids.Scripts.DI.Builder;

namespace Asteroids.Scripts.Core.Infrastructure.Installers
{
	public class GameStateMachineInstaller : IContainerInstaller
	{
		public void InstallTo(IContainerBuilder containerBuilder)
		{
			containerBuilder.Register<IGameStateMachine, GameStateMachine>();
			containerBuilder.Register<IGameStatesFactory, GameStatesFactory>();
		}
	}
}