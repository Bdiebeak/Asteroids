using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Base;
using Asteroids.Scripts.Core.Game.Features.Score.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Score
{
	public class ScoreFeature : Feature
	{
		public ScoreFeature(ISystemsFactory systemsFactory) : base(systemsFactory) { }

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(systemsFactory.CreateSystem<AddScoreFromEnemySystem>());
			systems.Add(systemsFactory.CreateSystem<HandleAddScoreRequestSystem>());
		}
	}
}