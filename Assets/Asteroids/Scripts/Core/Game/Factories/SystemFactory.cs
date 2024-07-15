using Asteroids.Scripts.DI.Container;

namespace Asteroids.Scripts.Core.Game.Factories
{
	public class SystemFactory : ISystemFactory
	{
		private readonly IContainer _container;

		public SystemFactory(IContainer container)
		{
			_container = container;
		}

		public TSystem CreateSystem<TSystem>()
		{
			return _container.CreateInstance<TSystem>();
		}
	}
}