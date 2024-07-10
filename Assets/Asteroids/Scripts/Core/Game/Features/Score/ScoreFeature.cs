using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Score.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Score
{
	public class ScoreFeature : Feature
	{
		private readonly ISystemsFactory _systemsFactory;

		public ScoreFeature(ISystemsFactory systemsFactory)
		{
			_systemsFactory = systemsFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemsFactory.CreateSystem<AddScoreOnEnemyDeathSystem>());
			systems.Add(_systemsFactory.CreateSystem<HandleAddScoreRequestSystem>());
		}
	}
}