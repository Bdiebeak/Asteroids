using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Score.Systems;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.Score
{
	public class ScoreFeature : Feature
	{
		private readonly ISystemFactory _systemFactory;

		public ScoreFeature(ISystemFactory systemFactory)
		{
			_systemFactory = systemFactory;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(_systemFactory.CreateSystem<AddScoreOnEnemyDeathSystem>());
			systems.Add(_systemFactory.CreateSystem<HandleAddScoreRequestSystem>());
		}
	}
}