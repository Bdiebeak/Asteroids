using Asteroids.Scripts.Core.Infrastructure.StateMachine;
using Asteroids.Scripts.Core.Infrastructure.StateMachine.States;
using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Extensions;

namespace Asteroids.Scripts.Core.Infrastructure.Installers
{
	public class GameStateMachineInstaller : IContainerInstaller
	{
		public void InstallTo(IContainerBuilder containerBuilder)
		{
			containerBuilder.Register<IGameStateMachine, GameStateMachine>();
			containerBuilder.Register<GameStatesFactory>();
			containerBuilder.Register<BootstrapState>();
			containerBuilder.Register<GameInitializeState>();
			containerBuilder.Register<GameLoopState>();
			containerBuilder.Register<GameRestartState>();
		}
	}
}