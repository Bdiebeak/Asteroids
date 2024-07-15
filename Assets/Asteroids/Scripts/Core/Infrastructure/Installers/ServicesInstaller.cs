﻿using Asteroids.Scripts.Core.Utilities.Services.Assets;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.Core.Utilities.Services.GameCamera;
using Asteroids.Scripts.Core.Utilities.Services.Input;
using Asteroids.Scripts.Core.Utilities.Services.Screens;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.DI.Builder;

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
			containerBuilder.Register<IScreenService, ScreenService>();
			containerBuilder.Register<IConfigService, DefaultConfigService>();
		}
	}
}