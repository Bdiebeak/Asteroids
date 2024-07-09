using System;
using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Collision.Requests;
using Asteroids.Scripts.Core.Game.Features.Requests;
using Asteroids.Scripts.Core.Game.Views;
using Asteroids.Scripts.DI.Attributes;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Collision
{
	public class CollisionListener : MonoBehaviour
	{
		private GameplayContext _gameplayContext;
		private LinkedEntityReference _linkedEntity;

		[Inject]
		public void Construct(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
		}

		private void Awake()
		{
			_linkedEntity = gameObject.GetComponent<LinkedEntityReference>();
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.TryGetComponent(out LinkedEntityReference collisionEntityReference) == false)
			{
				throw new Exception($"Can't find {nameof(LinkedEntityReference)} on colliding object.");
			}

			_gameplayContext.CreateRequest(new ProvideCollisionEnterRequest()
			{
				sender = _linkedEntity.Entity,
				collision = collisionEntityReference.Entity
			});
		}
	}
}