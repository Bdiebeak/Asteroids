﻿using System;
using Asteroids.Scripts.ECS.Components;

namespace Asteroids.Scripts.Core.Game.Features.Input.Components
{
	[Serializable]
	public class MoveInputComponent : IComponent
	{
		public float value;
	}
}