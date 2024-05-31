using Asteroids.Scripts.DI.Builder;

namespace Asteroids.Scripts.DI.Extensions
{
	public interface IContainerInstaller
	{
		void InstallTo(IContainerBuilder containerBuilder);
	}
}