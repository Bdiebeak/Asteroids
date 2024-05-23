﻿using System;
using System.Numerics;
using Asteroids.Scripts.ECS.Components;

namespace Asteroids.Scripts.Logic.Components
{
	[Serializable]
	public class MoveInputComponent : IComponent
	{
		public Vector2 value;
	}

	[Serializable]
	public class AttackInputComponent : IComponent
	{
		public bool isFiring;
	}
}