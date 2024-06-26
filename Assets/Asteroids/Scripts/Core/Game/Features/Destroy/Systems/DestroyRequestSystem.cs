﻿using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Destroy.Systems
{
	public class DestroyRequestSystem : IUpdateSystem, ICleanUpSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _mask;

		public DestroyRequestSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_mask = new Mask().Include<DestroyRequestComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				DestroyRequestComponent destroyRequest = entity.Get<DestroyRequestComponent>();
				if (destroyRequest.target == null)
				{
					Debug.LogError("Entity is null, can't destroy it.");
					continue;
				}
				if (destroyRequest.target.Has<DestroyComponent>())
				{
					continue;
				}
				destroyRequest.target.Add(new DestroyComponent());
			}
		}

		public void CleanUp()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				_gameplayContext.DestroyEntity(entity);
			}
		}
	}
}