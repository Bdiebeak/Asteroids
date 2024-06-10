using System;
using System.Numerics;
using Asteroids.Scripts.ECS.Components;

namespace Asteroids.Scripts.Core.Gameplay.Movement.Components
{
	[Serializable]
	public class PositionComponent : IComponent
	{
		public Vector2 value;
	}
}