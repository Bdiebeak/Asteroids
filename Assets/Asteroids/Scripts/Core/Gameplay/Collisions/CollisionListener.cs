using Asteroids.Scripts.Core.Gameplay.Collisions.Components;
using Asteroids.Scripts.Core.Gameplay.Contexts;
using Asteroids.Scripts.Core.Gameplay.Views;
using Asteroids.Scripts.DI.Resolver;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Gameplay.Collisions
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
			CollisionEnterEventComponent eventComponent = new()
			{
				sender = GetLinkedEntity().Entity,
				collision = other.gameObject.GetComponent<LinkedEntityReference>().Entity
			};

			Entity entity = _gameplayContext.CreateEntity();
			entity.Add(eventComponent);
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