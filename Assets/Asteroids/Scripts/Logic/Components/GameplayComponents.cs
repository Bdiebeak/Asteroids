using System;
using System.Numerics;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.Logic.View;

namespace Asteroids.Scripts.Logic.Components
{
	[Serializable]
	public class ViewComponent : IComponent
	{
		public IView value;
	}

	[Serializable]
	public class PlayerComponent : IComponent
	{
	}

	[Serializable]
	public class PositionComponent : IComponent
	{
		public Vector2 value;
	}

	[Serializable]
	public class RotationComponent : IComponent
	{
		public float value;
	}

	[Serializable]
	public class MoveDirectionComponent : IComponent
	{
		public Vector2 value;
	}

	[Serializable]
	public class AngularDirectionComponent : IComponent
	{
		public float value;
	}

	[Serializable]
	public class MoveSpeedComponent : IComponent
	{
		public float value;
	}

	[Serializable]
	public class AngularSpeedComponent : IComponent
	{
		public float value;
	}
}