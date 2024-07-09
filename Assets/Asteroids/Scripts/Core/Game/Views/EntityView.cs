using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Views
{
	public abstract class EntityView : MonoBehaviour
	{
		protected Entity entity;

		public void Construct(Entity entity)
		{
			this.entity = entity;
			OnConstruct();
		}

		protected abstract void OnConstruct();
	}
}