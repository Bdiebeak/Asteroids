using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Gameplay.Views
{
	public class LinkedEntity : MonoBehaviour
	{
		public Entity Entity { get; private set; }

		public void Initialize(Entity linkedEntity)
		{
			Entity = linkedEntity;
		}
	}
}