﻿using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Game.Features.Destroy.Requests;
using Asteroids.Scripts.Core.Game.Features.Owner.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Owner.Systems
{
	public class DestroyOwnedChildrenSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _ownerMask;

		public DestroyOwnedChildrenSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_ownerMask = new Mask().Include<OwnerReference>()
								   .Exclude<ToDestroyComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_ownerMask);
			foreach (Entity entity in entities)
			{
				OwnerReference owner = entity.Get<OwnerReference>();
				if (owner.value.Has<ToDestroyComponent>())
				{
					_gameplayContext.CreateRequest(new DestroyRequest
					{
						target = entity
					});
				}
			}
		}
	}
}