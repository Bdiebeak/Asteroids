using System.Numerics;
using Asteroids.Scripts.ECS.Components;

namespace Asteroids.Scripts.Logic.Components
{
	public class MoveInputComponent : IComponent
	{
		public Vector2 value;
	}

	public class AttackInputComponent : IComponent
	{
		public bool isFiring;
	}
}