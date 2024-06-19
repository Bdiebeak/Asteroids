using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Gameplay.Views
{
	public class LinkedEntityReference : MonoBehaviour
	{
		public Entity Entity { get; private set; }

		public void Initialize(Entity linkedEntity, bool destroyWithEntity)
		{
			Entity = linkedEntity;
			if (destroyWithEntity)
			{
				Entity.Destroyed += EntityOnDestroyed;
			}
		}

		private void OnDestroy()
		{
			Entity.Destroyed -= EntityOnDestroyed;
		}

		private void EntityOnDestroyed()
		{
			Destroy(gameObject);
		}
	}
}