﻿using System;
using Asteroids.Scripts.ECS.Components;

namespace Asteroids.Scripts.Core.Game.Features.Input.Components
{
	[Serializable]
	public class RotateInputComponent : IComponent
	{
		public float value;
	}
}