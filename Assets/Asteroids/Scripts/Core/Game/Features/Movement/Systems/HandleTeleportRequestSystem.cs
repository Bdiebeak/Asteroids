using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Movement.Requests;
using Asteroids.Scripts.Core.Game.Features.Requests;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Systems
{
	public class HandleTeleportRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;

		public HandleTeleportRequestSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
		}

		public void Update()
		{
			var entities = _gameplayContext.GetRequests<TeleportRequest>();
			foreach (Entity entity in entities)
			{
				TeleportRequest request = entity.Get<TeleportRequest>();
				Entity target = request.target;
				if (_gameplayContext.IsActive(target) == false)
				{
					Debug.LogError("Teleportation target isn't active.");
					continue;
				}

				target.Get<Position>().value = request.position;
			}

			_gameplayContext.DestroyRequests<TeleportRequest>();
		}
	}
}