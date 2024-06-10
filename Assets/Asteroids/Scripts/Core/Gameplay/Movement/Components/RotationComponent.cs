using System;
using Asteroids.Scripts.ECS.Components;

namespace Asteroids.Scripts.Core.Gameplay.Movement.Components
{
	[Serializable]
	public class RotationComponent : IComponent
	{
		public float value;
	}
}