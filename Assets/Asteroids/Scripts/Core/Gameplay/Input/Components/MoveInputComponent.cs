﻿using System;
using System.Numerics;
using Asteroids.Scripts.ECS.Components;

namespace Asteroids.Scripts.Core.Gameplay.Input.Components
{
	[Serializable]
	public class MoveInputComponent : IComponent
	{
		public float value;
	}
}