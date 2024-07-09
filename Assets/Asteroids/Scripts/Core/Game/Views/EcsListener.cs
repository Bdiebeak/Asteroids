using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Views
{
	[RequireComponent(typeof(EntityView))]
	public abstract class EcsListener : MonoBehaviour
	{
		public abstract void Construct(Entity entity);
	}
}