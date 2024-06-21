using Asteroids.Scripts.Core.Game;
using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Extensions;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Installers
{
	public class GameInstaller : IContainerInstaller
	{
		private readonly Camera _mainCamera;

		public GameInstaller(Camera mainCamera)
		{
			_mainCamera = mainCamera;
		}

		public void InstallTo(IContainerBuilder containerBuilder)
		{
			containerBuilder.Register<IGameFactory, GameFactory>();
			containerBuilder.Register<InputContext>();
			containerBuilder.Register<GameplayContext>();
			containerBuilder.Register<EcsStartup>();
			containerBuilder.Register<Camera>(_mainCamera);
		}
	}
}