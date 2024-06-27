using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Base;
using Asteroids.Scripts.Core.Game.Features.Input.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Input
{
	public class AttackInputFeature : Feature
	{
		public AttackInputFeature(ISystemsFactory systemsFactory) : base(systemsFactory) { }

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(systemsFactory.CreateSystem<UpdateBulletAttackInputSystem>());
			systems.Add(systemsFactory.CreateSystem<UpdateLaserAttackInputSystem>());
		}
	}
}