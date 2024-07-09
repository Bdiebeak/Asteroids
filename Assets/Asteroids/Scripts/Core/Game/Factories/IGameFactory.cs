using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Factories
{
	public interface IGameFactory
	{
		Camera CreateMainCamera();
		Entity CreatePlayer(Vector2 position);
		Entity CreateAsteroid(Vector2 position);
		Entity CreateAsteroidPiece(Vector2 position);
		Entity CreateUfo(Vector2 position);
		Entity CreateBullet(Vector2 position, Vector2 direction);
		Entity CreateLaser(Vector2 position, float rotation, Entity shooter, float destroyTime);
	}
}