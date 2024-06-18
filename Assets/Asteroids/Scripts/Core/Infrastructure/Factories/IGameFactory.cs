using Asteroids.Scripts.Core.Gameplay.Enemies;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Factories
{
	public interface IGameFactory
	{
		Camera CreateMainCamera();
		void CreatePlayer();
		void CreateEnemy(EnemyType enemyType);
	}
}