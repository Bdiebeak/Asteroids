﻿using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Destroy.Requests;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Destroy.Systems
{
	public class HandleDestroyWithTimerRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;

		public HandleDestroyWithTimerRequestSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
		}

		public void Update()
		{
			var entities = _gameplayContext.GetRequests<DestroyWithTimerRequest>();
			foreach (Entity entity in entities)
			{
				DestroyWithTimerRequest request = entity.Get<DestroyWithTimerRequest>();
				if (_gameplayContext.TryGetEntity(request.targetEntityId, out Entity target) == false)
				{
					Debug.LogError("Can't get entity to destroy.");
					continue;
				}

				target.Add(new DestroyTimerComponent()).value = request.timer;
			}

			_gameplayContext.DestroyRequests<DestroyWithTimerRequest>();
		}
	}
}