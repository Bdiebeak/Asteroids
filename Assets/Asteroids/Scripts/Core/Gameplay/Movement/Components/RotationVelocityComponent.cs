using System;
using Asteroids.Scripts.ECS.Components;

namespace Asteroids.Scripts.Core.Gameplay.Movement.Components
{
	[Serializable]
	public class RotationVelocityComponent : IComponent
	{
		public float value;
	}
}