﻿using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Components
{
	public class CopyTargetRotation : IComponent
	{
		public Entity target;
	}
}