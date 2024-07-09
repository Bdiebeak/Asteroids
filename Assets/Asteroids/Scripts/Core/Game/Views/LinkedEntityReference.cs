using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Views
{
	public class LinkedEntityReference : MonoBehaviour
	{
		public Entity Entity { get; private set; }

		public void Construct(Entity linkedEntity)
		{
			Entity = linkedEntity;
		}
	}
}