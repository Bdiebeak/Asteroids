using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Extensions;
using UnityEngine;

namespace Asteroids.Scripts.Unity.Infrastructure.Installers
{
	public abstract class MonoInstaller : MonoBehaviour,  IContainerInstaller
	{
		public abstract void InstallTo(IContainerBuilder containerBuilder);
	}
}