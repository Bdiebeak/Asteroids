using Asteroids.Scripts.Core.Gameplay;
using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Extensions;

namespace Asteroids.Scripts.Core.Infrastructure.Installers
{
	public class UIInstaller : IContainerInstaller
	{
		public void InstallTo(IContainerBuilder containerBuilder)
		{
			containerBuilder.Register<EcsStartup>();
		}
	}
}