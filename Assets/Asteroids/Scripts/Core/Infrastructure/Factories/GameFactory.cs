using System;
using Asteroids.Scripts.Core.Gameplay.Enemies;
using Asteroids.Scripts.Core.Infrastructure.Constants;
using Asteroids.Scripts.Core.Infrastructure.Services.Assets;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure.Factories
{
	public class GameFactory : IGameFactory
	{
		private readonly IPrefabCreator _prefabCreator;

		public GameFactory(IPrefabCreator prefabCreator)
		{
			_prefabCreator = prefabCreator;
		}

		public void CreatePlayer(Vector2 position)
		{
			GameObject player = _prefabCreator.Instantiate(AssetKeys.Player);
			player.transform.position = position;
		}

		public void CreateEnemy(EnemyType enemyType, Vector2 position)
		{
			GameObject enemy;
			switch (enemyType)
			{
				case EnemyType.Asteroid:
					enemy = _prefabCreator.Instantiate(AssetKeys.Asteroid);
					break;

				case EnemyType.AsteroidPiece:
					enemy = _prefabCreator.Instantiate(AssetKeys.AsteroidPiece);
					break;

				case EnemyType.Ufo:
					enemy = _prefabCreator.Instantiate(AssetKeys.Ufo);
					break;

				default:
					throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, null);
			}
			enemy.transform.position = position;
		}
	}
}