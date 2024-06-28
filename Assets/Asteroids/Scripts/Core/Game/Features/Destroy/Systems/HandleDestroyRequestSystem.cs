using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Destroy.Requests;
using Asteroids.Scripts.Core.Game.Features.Requests;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Destroy.Systems
{
	public class HandleDestroyRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;

		public HandleDestroyRequestSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
		}

		public void Update()
		{
			var entities = _gameplayContext.GetRequests<DestroyRequest>();
			foreach (Entity entity in entities)
			{
				DestroyRequest destroyRequest = entity.Get<DestroyRequest>();

				if (_gameplayContext.IsActive(destroyRequest.target) == false)
				{
					Debug.LogError("Entity isn't active, can't destroy it.");
					continue;
				}

				if (destroyRequest.target.Has<ToDestroy>())
				{
					continue;
				}

				destroyRequest.target.Add(new ToDestroy());
			}

			_gameplayContext.DestroyRequests<DestroyRequest>();
		}
	}
}