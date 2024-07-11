using System;
using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Collision.Requests;
using Asteroids.Scripts.Core.Game.Views;
using Asteroids.Scripts.DI.Attributes;
using Asteroids.Scripts.ECS.Requests;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Collision
{
	[RequireComponent(typeof(EntityView))]
	public class CollisionProvider : MonoBehaviour
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

			_gameplayContext.CreateRequest(new ProvideCollisionEnterRequest
			{
				sender = _entityView.LinkedEntity,
				collision = collisionEntityView.LinkedEntity
			});
		}
	}
}