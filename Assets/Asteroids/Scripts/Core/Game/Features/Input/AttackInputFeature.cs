using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Input.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Input
{
	public class AttackInputFeature : Feature
	{
		private readonly ISystemFactory _systemFactory;

		public AttackInputFeature(ISystemFactory systemFactory)
		{
			_systemFactory = systemFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemFactory.CreateSystem<UpdateBulletAttackInputSystem>());
			systems.Add(_systemFactory.CreateSystem<UpdateLaserAttackInputSystem>());
		}
	}
}