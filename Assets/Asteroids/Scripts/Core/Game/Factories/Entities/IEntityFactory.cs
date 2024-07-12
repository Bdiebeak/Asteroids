using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Factories.Entities
{
	public interface IEntityFactory
	{
		Entity CreatePlayer(Vector2 position, float speed, float rotationSpeed, float acceleration, float deceleration, float bulletAttackRate, float laserAttackRate, float laserChargeTime, int laserCharges);
		Entity CreateAsteroid(Vector2 position, Vector2 moveDirection, int piecesCount, float speed, int score);
		Entity CreateAsteroidPiece(Vector2 position, Vector2 moveDirection, float speed, int score);
		Entity CreateUfo(Vector2 position, float speed, int score);
		Entity CreateUfoSpawner(float spawnTimer);
		Entity CreateBullet(Vector2 position, Vector2 direction, float speed);
		Entity CreateLaser(Vector2 position, float rotation, Entity shooter, float activeTime);
	}
}