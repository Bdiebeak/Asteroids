using System.Collections.Generic;
using Asteroids.Scripts.Core.Game.Features.Enemies;
using Asteroids.Scripts.Core.Game.Features.Weapon;

namespace Asteroids.Scripts.Core.Infrastructure.Services.Configs
{
	public static class GameConfig
	{
		public const float ShipAngularSpeed = 200f;
		public const float ShipAcceleration = 9f;
		public const float ShipMaxSpeed = 8.5f;
		public const float ShipDrag = 1.25f;
		public const float ScreenBorderOffset = 0.35f;

		public const int MaxLaserCharges = 2;

		public static Dictionary<WeaponType, float> WeaponsCooldown = new()
		{
			{WeaponType.Bullet, 1},
			{WeaponType.Laser, 5}
		};

		public static Dictionary<EnemyType, float> EnemiesSpeed = new()
		{
			{EnemyType.Asteroid, 2},
			{EnemyType.AsteroidPiece, 4},
			{EnemyType.Ufo, 8}
		};

		public static Dictionary<EnemyType, int> EnemiesScore = new()
		{
			{EnemyType.Asteroid, 50},
			{EnemyType.AsteroidPiece, 75},
			{EnemyType.Ufo, 100}
		};
	}
}