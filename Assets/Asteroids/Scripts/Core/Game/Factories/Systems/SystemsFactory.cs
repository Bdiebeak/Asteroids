using Asteroids.Scripts.DI.Container;

namespace Asteroids.Scripts.Core.Game.Factories.Systems
{
	public class SystemsFactory : ISystemsFactory
	{
		private readonly IContainer _container;

		public SystemsFactory(IContainer container)
		{
			_container = container;
		}

		public TSystem CreateSystem<TSystem>()
		{
			return _container.CreateInstance<TSystem>();
		}
	}
}