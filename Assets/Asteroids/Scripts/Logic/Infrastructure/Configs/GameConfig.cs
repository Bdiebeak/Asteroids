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
			{EnemyType.BigAsteroid, 1f},
			{EnemyType.MiddleAsteroid, 0.5f},
			{EnemyType.LittleAsteroid, 0.25f},
			{EnemyType.UFO, 0.5f}
		};
		public static Dictionary<EnemyType, float> EnemiesSpeed = new()
		{
			{EnemyType.BigAsteroid, 2},
			{EnemyType.MiddleAsteroid, 4},
			{EnemyType.LittleAsteroid, 6},
			{EnemyType.UFO, 8}
		};
		public static Dictionary<EnemyType, int> EnemiesScore = new()
		{
			{EnemyType.BigAsteroid, 50},
			{EnemyType.MiddleAsteroid, 75},
			{EnemyType.LittleAsteroid, 100},
			{EnemyType.UFO, 125}
		};
	}
}