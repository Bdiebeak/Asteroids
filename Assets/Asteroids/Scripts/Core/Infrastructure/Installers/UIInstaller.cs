using Asteroids.Scripts.Core.UI.Factory;
using Asteroids.Scripts.Core.UI.Models;
using Asteroids.Scripts.DI.Builder;

namespace Asteroids.Scripts.Core.Infrastructure.Installers
{
	public class UIInstaller : IContainerInstaller
	{
		public void InstallTo(IContainerBuilder containerBuilder)
		{
			containerBuilder.Register<IUIFactory, UIFactory>();
			containerBuilder.Register<StartScreenModel>();
			containerBuilder.Register<GameScreenModel>();
			containerBuilder.Register<GameOverScreenModel>();
		}
	}
}