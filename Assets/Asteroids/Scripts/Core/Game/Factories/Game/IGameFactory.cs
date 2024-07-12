using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Factories.Game
{
	public interface IGameFactory
	{
		Camera CreateMainCamera();
		void CreatePlayer(Vector2 position);
		void CreateAsteroid(Vector2 position);
		void CreateAsteroidPiece(Vector2 position);
		void CreateUfo(Vector2 position);
		void CreateBullet(Vector2 position, Vector2 direction);
		void CreateLaser(Vector2 position, float rotation, Entity shooter);
	}
}