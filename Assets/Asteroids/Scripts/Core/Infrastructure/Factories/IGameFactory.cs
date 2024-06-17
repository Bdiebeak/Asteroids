using Asteroids.Scripts.Core.Gameplay.Enemies;
using Asteroids.Scripts.Core.Gameplay.View;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Factories
{
	public interface IGameFactory
	{
		Camera CreateMainCamera();
		IView CreatePlayer();
		IView CreateEnemy(EnemyType enemyType);
	}
}