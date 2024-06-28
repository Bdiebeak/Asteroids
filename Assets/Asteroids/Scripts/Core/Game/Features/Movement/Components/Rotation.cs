﻿using System;
using Asteroids.Scripts.ECS.Components;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Components
{
	[Serializable]
	public class Rotation : IComponent
	{
		public float value;
	}
}