﻿using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Weapon.Requests
{
	public class ShootBulletRequest : IRequest
	{
		public Entity shooter;
		public Vector2 position;
		public Vector2 direction;
	}
}