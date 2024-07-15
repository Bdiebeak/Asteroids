using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Destroy.Requests;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
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
				if (_gameplayContext.TryGetEntity(destroyRequest.targetEntityId, out Entity target) == false)
				{
					Debug.LogError("Can't get entity to destroy.");
					continue;
				}

				if (target.Has<ToDestroyComponent>())
				{
					continue;
				}

				target.Add(new ToDestroyComponent());
			}

			_gameplayContext.DestroyRequests<DestroyRequest>();
		}
	}
}