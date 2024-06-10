using Asteroids.Scripts.Core.Infrastructure.Services;
using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Extensions;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Installers
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