using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Extensions;
using Asteroids.Scripts.Logic.Infrastructure;
using Asteroids.Scripts.Logic.Infrastructure.Services;
using Asteroids.Scripts.Unity.Infrastructure.Services;
using UnityEngine;

namespace Asteroids.Scripts.Unity.Infrastructure.Installers
{
	public class ServicesInstaller : MonoInstaller
	{
		[SerializeField]
		private ViewFactory viewFactory;

		public override void InstallTo(IContainerBuilder containerBuilder)
		{
			containerBuilder.Register<IInputService, UnityInputService>();
			containerBuilder.Register<IViewFactory>(viewFactory);
			containerBuilder.Register<EcsStartup>();
		}
	}
}