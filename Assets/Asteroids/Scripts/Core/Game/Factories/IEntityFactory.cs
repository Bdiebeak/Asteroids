using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Factories
{
	public interface IEntityFactory
	{
		Entity CreatePlayer(Vector2 position, float speed, float rotationSpeed, float acceleration, float deceleration, int maxLaserCharges);
		Entity CreateAsteroid(Vector2 position, Vector2 moveDirection, float speed, int score);
		Entity CreateAsteroidPiece(Vector2 position, Vector2 moveDirection, float speed, int score);
		Entity CreateUfo(Vector2 position, float speed, int score);
		Entity CreateBullet(Vector2 position, Vector2 direction, float speed);
		Entity CreateLaser(Vector2 position, float rotation, Entity shooter, float destroyTime);
	}
}