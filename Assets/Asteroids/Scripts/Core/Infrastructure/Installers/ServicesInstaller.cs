using Asteroids.Scripts.Core.Utilities.Services.Assets;
using Asteroids.Scripts.Core.Utilities.Services.Camera;
using Asteroids.Scripts.Core.Utilities.Services.Input;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Extensions;

namespace Asteroids.Scripts.Core.Infrastructure.Installers
{
	public class ServicesInstaller : IContainerInstaller
	{
		public void InstallTo(IContainerBuilder containerBuilder)
		{
			containerBuilder.Register<IAssetProvider, ResourcesAssetProvider>();
			containerBuilder.Register<IInputService, UnityInputService>();
			containerBuilder.Register<ITimeService, UnityTimeService>();
			containerBuilder.Register<ICameraService, CameraService>();
		}
	}
}