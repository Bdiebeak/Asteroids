using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Score.Components;
using Asteroids.Scripts.Core.Game.Features.Score.Requests;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Score.Systems
{
	public class HandleAddScoreRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _scoreCounterMask;

		public HandleAddScoreRequestSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_scoreCounterMask = new Mask().Include<ScoreCounter>();
		}

		public void Update()
		{
			var requestEntities = _gameplayContext.GetRequests<AddScoreRequest>();
			var scoreCounterEntities = _gameplayContext.GetEntities(_scoreCounterMask);
			foreach (Entity requestEntity in requestEntities)
			{
				AddScoreRequest addRequest = requestEntity.Get<AddScoreRequest>();

				foreach (Entity counterEntity in scoreCounterEntities)
				{
					ScoreCounter scoreCounter = counterEntity.Get<ScoreCounter>();
					scoreCounter.value += addRequest.value;
				}
			}

			_gameplayContext.DestroyRequests<AddScoreRequest>();
		}
	}
}