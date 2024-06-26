using System;
using Asteroids.Scripts.ECS.Components;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Movement.Components
{
	[Serializable]
	public class Position : IComponent
	{
		public Vector2 value;
	}
}