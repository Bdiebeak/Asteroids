using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Base;
using Asteroids.Scripts.Core.Game.Features.Input;
using Asteroids.Scripts.Core.Game.Features.Input.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features
{
	public class InputFeatures : Feature
	{
		public InputFeatures(ISystemsFactory systemsFactory) : base(systemsFactory) { }

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(systemsFactory.CreateSystem<InitializeInputSystem>());
			systems.Add(new MotionInputFeature(systemsFactory));
			systems.Add(new AttackInputFeature(systemsFactory));
		}
	}
}