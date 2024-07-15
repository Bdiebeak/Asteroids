using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Factories.Entities
{
	public interface IEntityFactory
	{
		Entity CreatePlayer(Vector2 position);
		Entity CreateAsteroid(Vector2 position, Vector2 moveDirection);
		Entity CreateAsteroidPiece(Vector2 position, Vector2 moveDirection);
		Entity CreateUfo(Vector2 position);
		Entity CreateUfoSpawner(float spawnTimer);
		Entity CreateBullet(Vector2 position, Vector2 direction);
		Entity CreateLaser(Vector2 position, float rotation, int shooterId);
	}
}