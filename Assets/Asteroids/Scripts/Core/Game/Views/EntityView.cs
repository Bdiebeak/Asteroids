using System.Collections.Generic;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Views
{
	public class EntityView : MonoBehaviour
	{
		[SerializeField]
		private List<EcsListener> listeners = new();

		public Entity LinkedEntity { get; private set; }

		public void Initialize(Entity entity)
		{
			LinkedEntity = entity;
			foreach (EcsListener listener in listeners)
			{
				listener.Initialize(entity);
			}
		}
	}
}