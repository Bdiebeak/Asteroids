using Asteroids.Scripts.Core.Game.Factories.Systems;
using Asteroids.Scripts.Core.Game.Features.UI.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.UI
{
	public class UIFeature : Feature
	{
		private readonly ISystemsFactory _systemsFactory;

		public UIFeature(ISystemsFactory systemsFactory)
		{
			_systemsFactory = systemsFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemsFactory.CreateSystem<UpdateScreenModelsSystem>());
		}
	}
}