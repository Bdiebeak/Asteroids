using Asteroids.Scripts.Core.Gameplay;
using Asteroids.Scripts.Core.Infrastructure.Factories;
using Asteroids.Scripts.Core.Infrastructure.Services.AssetProvider;
using Asteroids.Scripts.Core.Infrastructure.Services.Input;
using Asteroids.Scripts.Core.UI.Base;
using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Extensions;

namespace Asteroids.Scripts.Core.Infrastructure.Installers
{
	public class ServicesInstaller : IContainerInstaller
	{
		public void InstallTo(IContainerBuilder containerBuilder)
		{
			containerBuilder.Register<IInputService, UnityInputService>();
			containerBuilder.Register<IAssetProvider, ResourcesAssetProvider>();
			containerBuilder.Register<IGameFactory, GameFactory>();
			containerBuilder.Register<IUIFactory, UIFactory>();
			containerBuilder.Register<IScreenService, ScreenService>();
			containerBuilder.Register<EcsStartup>();
		}
	}
}