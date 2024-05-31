using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Container;
using Asteroids.Scripts.DI.Extensions;
using Asteroids.Scripts.Logic.Infrastructure;
using Asteroids.Scripts.Logic.Infrastructure.Services;
using Asteroids.Scripts.Unity.Infrastructure.Services;

namespace Asteroids.Scripts.Unity
{
	public class ServicesInstaller : IContainerInstaller
	{
		public void InstallTo(IContainerBuilder containerBuilder)
		{
			containerBuilder.Register<IInputService, UnityInputService>();
			containerBuilder.Register<IViewFactory, ViewFactory>();
			containerBuilder.Register<EcsStartup>();
		}
	}
}