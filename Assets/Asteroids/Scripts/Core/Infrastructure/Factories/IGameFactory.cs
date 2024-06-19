using Asteroids.Scripts.Core.Gameplay.Enemies;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Factories
{
	public interface IGameFactory
	{
		Camera CreateMainCamera();
		void CreatePlayer(Vector2 position);
		void CreateEnemy(EnemyType enemyType, Vector2 position);
	}
}