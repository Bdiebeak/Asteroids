using Asteroids.Scripts.Core.Game;
using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories.Entities;
using Asteroids.Scripts.Core.Game.Factories.Game;
using Asteroids.Scripts.Core.Game.Factories.Systems;
using Asteroids.Scripts.Core.Game.Factories.Views;
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
			// TODO: don't like 3 different factories, rework and refactor it.
			containerBuilder.Register<IEntityFactory, EntityFactory>();
			containerBuilder.Register<IViewFactory, ViewFactory>();
			containerBuilder.Register<IGameFactory, GameFactory>();
			containerBuilder.Register<ISystemsFactory, SystemsFactory>();
			containerBuilder.Register<InputContext>();
			containerBuilder.Register<GameplayContext>();
			containerBuilder.Register<EcsStartup>();
		}
	}
}