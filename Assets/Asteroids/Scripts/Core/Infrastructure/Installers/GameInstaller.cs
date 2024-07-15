using Asteroids.Scripts.Core.Game;
using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Infrastructure.StateMachine;
using Asteroids.Scripts.DI.Builder;

namespace Asteroids.Scripts.Core.Infrastructure.Installers
{
	public class GameInstaller : IContainerInstaller
	{
		public void InstallTo(IContainerBuilder containerBuilder)
		{
			containerBuilder.Register<IGameStateMachine, GameStateMachine>();
			containerBuilder.Register<IGameStatesFactory, GameStatesFactory>();
			containerBuilder.Register<IGameFactory, GameFactory>();
			containerBuilder.Register<ISystemFactory, SystemFactory>();
			containerBuilder.Register<InputContext>();
			containerBuilder.Register<GameplayContext>();
			containerBuilder.Register<EcsStartup>();
		}
	}
}