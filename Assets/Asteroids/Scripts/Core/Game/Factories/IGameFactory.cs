using Asteroids.Scripts.Core.Game.Features.Enemies;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Factories
{
	public interface IGameFactory
	{
		Camera CreateMainCamera();
		void CreatePlayer(Vector2 position);
		void CreateEnemy(EnemyType enemyType, Vector2 position);
		void CreateBullet(Vector2 position, float rotation);
	}
}