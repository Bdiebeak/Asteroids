using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Score.Components;
using Asteroids.Scripts.Core.Game.Features.Score.Requests;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Score.Systems
{
	public class AddScoreOnEnemyDeathSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _enemyMask;

		public AddScoreOnEnemyDeathSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_enemyMask = new Mask().Include<EnemyComponent>()
								   .Include<ScoreRewardComponent>()
								   .Include<ToDestroyComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_enemyMask);
			foreach (Entity entity in entities)
			{
				ScoreRewardComponent score = entity.Get<ScoreRewardComponent>();
				_gameplayContext.CreateRequest(new AddScoreRequest
				{
					value = score.value
				});
			}
		}
	}
}