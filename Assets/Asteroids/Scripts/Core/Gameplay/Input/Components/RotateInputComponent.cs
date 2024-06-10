using System;
using Asteroids.Scripts.ECS.Components;

namespace Asteroids.Scripts.Core.Gameplay.Input.Components
{
	[Serializable]
	public class RotateInputComponent : IComponent
	{
		public float value;
	}
}