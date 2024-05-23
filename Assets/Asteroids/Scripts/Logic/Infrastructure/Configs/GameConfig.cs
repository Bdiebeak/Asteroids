using System.Collections.Generic;
using Asteroids.Scripts.Logic.Enemies;
using Asteroids.Scripts.Logic.Weapons;

namespace Asteroids.Scripts.Logic.Infrastructure.Configs
{
	public static class GameConfig
	{
		public const float ShipAngularSpeed = 150;
		public const float ShipMoveSpeed = 2;

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