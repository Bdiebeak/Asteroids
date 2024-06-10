using System;
using Asteroids.Scripts.ECS.Components;

namespace Asteroids.Scripts.Core.Gameplay.Movement.Components
{
	[Serializable]
	public class MoveSpeedComponent : IComponent
	{
		public float value;
	}
}