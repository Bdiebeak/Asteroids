using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Factories
{
	public interface IGameFactory
	{
		Camera CreateMainCamera();
		void CreatePlayer(Vector2 position);
		void CreateAsteroid(Vector2 position, Vector2 moveDirection);
		void CreateAsteroidPiece(Vector2 position, Vector2 moveDirection);
		void CreateUfo(Vector2 position);
		void CreateBullet(Vector2 position, Vector2 moveDirection);
		void CreateLaser(Vector2 position, float rotation, int shooterId);
	}
}