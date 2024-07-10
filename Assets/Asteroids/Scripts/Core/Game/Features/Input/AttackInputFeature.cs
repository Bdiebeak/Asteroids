using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Input.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Input
{
	public class AttackInputFeature : Feature
	{
		private readonly ISystemsFactory _systemsFactory;

		public AttackInputFeature(ISystemsFactory systemsFactory)
		{
			_systemsFactory = systemsFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemsFactory.CreateSystem<UpdateBulletAttackInputSystem>());
			systems.Add(_systemsFactory.CreateSystem<UpdateLaserAttackInputSystem>());
		}
	}
}