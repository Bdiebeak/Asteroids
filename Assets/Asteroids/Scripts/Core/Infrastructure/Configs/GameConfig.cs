using System.Collections.Generic;
using Asteroids.Scripts.Core.Gameplay.Enemies;
using Asteroids.Scripts.Core.Gameplay.Weapons;

namespace Asteroids.Scripts.Core.Infrastructure.Configs
{
	public static class GameConfig
	{
		public const float ShipAngularSpeed = 220f;
		public const float ShipAcceleration = 10f;
		public const float ShipMaxSpeed = 5f;
		public const float ShipDrag = 2f;

		public static Dictionary<WeaponType, float> WeaponsScale = new()
		{
			{WeaponType.Bullet, 0.1f},
			{WeaponType.Laser, 0.2f}
		};
		public static Dictionary<WeaponType, float> WeaponsCooldown = new()
		{
			{WeaponType.Bullet, 1},
			{WeaponType.Laser, 5}
		};
		public const int MaxLaserCharges = 2;

		public static Dictionary<EnemyType, float> EnemiesScale = new()
		{
			{EnemyType.Asteroid, 1f},
			{EnemyType.AsteroidPiece, 0.5f},
			{EnemyType.Ufo, 0.5f}
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