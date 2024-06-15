﻿using System;
using Asteroids.Scripts.ECS.Components;
using UnityEngine;

namespace Asteroids.Scripts.Core.Gameplay.Movement.Components
{
	[Serializable]
	public class PositionComponent : IComponent
	{
		public Vector2 value;
	}
}