using Asteroids.Scripts.Core.Game.Factories.Systems;
using Asteroids.Scripts.Core.Game.Features.Input;
using Asteroids.Scripts.Core.Game.Features.Input.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features
{
	public class InputFeatures : Feature
	{
		private readonly ISystemsFactory _systemsFactory;

		public InputFeatures(ISystemsFactory systemsFactory)
		{
			_systemsFactory = systemsFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemsFactory.CreateSystem<InitializeInputSystem>());
			systems.Add(new MotionInputFeature(_systemsFactory));
			systems.Add(new AttackInputFeature(_systemsFactory));
		}
	}
}