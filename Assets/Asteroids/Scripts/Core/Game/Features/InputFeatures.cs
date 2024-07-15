using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Input;
using Asteroids.Scripts.Core.Game.Features.Input.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features
{
	public class InputFeatures : Feature
	{
		private readonly ISystemFactory _systemFactory;

		public InputFeatures(ISystemFactory systemFactory)
		{
			_systemFactory = systemFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemFactory.CreateSystem<InitializeInputSystem>());
			systems.Add(new MotionInputFeature(_systemFactory));
			systems.Add(new AttackInputFeature(_systemFactory));
		}
	}
}