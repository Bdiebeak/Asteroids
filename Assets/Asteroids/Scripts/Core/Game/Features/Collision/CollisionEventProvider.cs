using System;
using Asteroids.Scripts.Core.Game.Behaviours;
using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Collision.Events;
using Asteroids.Scripts.DI.Attributes;
using Asteroids.Scripts.ECS.Events;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Collision
{
	[RequireComponent(typeof(EntityView))]
	public class CollisionEventProvider : MonoBehaviour
	{
		private GameplayContext _gameplayContext;
		private EntityView _entityView;

		[Inject]
		public void Construct(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
		}

		private void Awake()
		{
			_entityView = gameObject.GetComponent<EntityView>();
			if (_entityView == null)
			{
				throw new InvalidOperationException($"Can't get {nameof(EntityView)} on colliding object. " +
													"It's required to provide collision event in ECS world.");
			}
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.TryGetComponent(out EntityView collisionEntityView) == false)
			{
				throw new InvalidOperationException($"Can't find {nameof(EntityView)} on colliding object. " +
													"It's required to provide collision event in ECS world.");
			}

			_gameplayContext.CreateEvent(new CollisionEnterEvent()
			{
				senderEntityId = _entityView.LinkedEntity.Id,
				collisionEntityId = collisionEntityView.LinkedEntity.Id
			});
		}
	}
}