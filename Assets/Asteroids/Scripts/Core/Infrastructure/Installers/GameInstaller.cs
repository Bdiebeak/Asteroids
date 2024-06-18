using Asteroids.Scripts.Core.Gameplay;
using Asteroids.Scripts.Core.Gameplay.Contexts;
using Asteroids.Scripts.Core.Infrastructure.Factories;
using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Extensions;

namespace Asteroids.Scripts.Core.Infrastructure.Installers
{
	public class GameInstaller : IContainerInstaller
	{
		public void InstallTo(IContainerBuilder containerBuilder)
		{
			containerBuilder.Register<IGameFactory, GameFactory>();
			containerBuilder.Register<InputContext>();
			containerBuilder.Register<GameplayContext>();
			containerBuilder.Register<EcsStartup>();
		}
	}
}