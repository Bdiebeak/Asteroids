using System.Numerics;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.Logic.View;

namespace Asteroids.Scripts.Logic.Components
{
	public class ViewComponent : IComponent
	{
		public IView value;
	}

	public class PlayerComponent : IComponent
	{
	}

	public class PositionComponent : IComponent
	{
		public Vector2 value;
	}

	public class RotationComponent : IComponent
	{
		public float value;
	}

	public class MoveDirectionComponent : IComponent
	{
		public Vector2 value;
	}

	public class AngularDirectionComponent : IComponent
	{
		public float value;
	}

	public class MoveSpeedComponent : IComponent
	{
		public float value;
	}

	public class AngularSpeedComponent : IComponent
	{
		public float value;
	}
}