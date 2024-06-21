using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Enemies;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Spawn.Systems
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