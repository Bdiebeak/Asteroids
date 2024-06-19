using Asteroids.Scripts.Core.Infrastructure.Factories;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Gameplay.Enemies.Systems
{
	public class SpawnEnemySystem : IStartSystem
	{
		private readonly IGameFactory _gameFactory;

		public SpawnEnemySystem(IGameFactory gameFactory)
		{
			_gameFactory = gameFactory;
		}

		public void Start()
		{
			_gameFactory.CreateEnemy(EnemyType.Asteroid, new Vector2(2, 2));
		}
	}
}