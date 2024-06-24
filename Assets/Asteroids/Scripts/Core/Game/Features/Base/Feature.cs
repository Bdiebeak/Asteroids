using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Base
{
	public abstract class Feature
	{
		protected readonly ISystemsFactory systemsFactory;

		public Feature(ISystemsFactory systemsFactory)
		{
			this.systemsFactory = systemsFactory;
		}

		public abstract void AddTo(SystemsContainer systems);
	}
}