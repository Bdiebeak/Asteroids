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

		private void OnCollisionEnter2D(Collision2D other)
		{
			_gameplayContext.CreateRequest(new ProvideCollisionEnterRequest()
			{
				sender = GetLinkedEntity().Entity,
				collision = other.gameObject.GetComponent<LinkedEntityReference>().Entity
			});
		}

		private LinkedEntityReference GetLinkedEntity()
		{
			if (_linkedEntity == null)
			{
				_linkedEntity = gameObject.GetComponent<LinkedEntityReference>();
			}
			return _linkedEntity;
		}
	}
}