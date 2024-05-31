using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Container;
using Asteroids.Scripts.DI.Extensions;
using Asteroids.Scripts.Logic.Infrastructure.StateMachine;
using Asteroids.Scripts.Logic.Infrastructure.StateMachine.States;

namespace Asteroids.Scripts.Unity
{
	public class GameStateMachineInstaller : IContainerInstaller
	{
		public void InstallTo(IContainerBuilder containerBuilder)
		{
			containerBuilder.Register<IGameStateMachine, GameStateMachine>();
			containerBuilder.Register<BootstrapState>();
			containerBuilder.Register<GameInitializeState>();
			containerBuilder.Register<GameLoopState>();
			containerBuilder.Register<GameRestartState>();
		}
	}
}