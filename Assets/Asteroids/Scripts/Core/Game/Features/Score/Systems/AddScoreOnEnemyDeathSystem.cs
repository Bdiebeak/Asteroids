﻿using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Score.Components;
using Asteroids.Scripts.Core.Game.Features.Score.Requests;
using Asteroids.Scripts.Core.Game.Requests;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Score.Systems
{
	public class AddScoreOnEnemyDeathSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _mask;

		public AddScoreOnEnemyDeathSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_mask = new Mask().Include<EnemyMarker>()
							  .Include<ScorePoints>()
							  .Include<ToDestroy>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				ScorePoints score = entity.Get<ScorePoints>();
				_gameplayContext.CreateRequest(new AddScoreRequest
				{
					value = score.value
				});
			}
		}
	}
}