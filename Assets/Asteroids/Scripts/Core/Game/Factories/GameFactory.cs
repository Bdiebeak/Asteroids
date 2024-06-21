using System;
using Asteroids.Scripts.Core.Game.Features.Enemies;
using Asteroids.Scripts.Core.Infrastructure.Services.Assets;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Factories
{
	public class GameFactory : IGameFactory
	{
		private readonly IPrefabCreator _prefabCreator;

		public GameFactory(IPrefabCreator prefabCreator)
		{
			_prefabCreator = prefabCreator;
		}

		public Camera CreateMainCamera()
		{
			return _prefabCreator.InstantiateComponent<Camera>(GameAssetKeys.MainCamera);
		}

		public void CreatePlayer(Vector2 position)
		{
			InstantiateAt(GameAssetKeys.Player, position);
		}

		public void CreateEnemy(EnemyType enemyType, Vector2 position)
		{
			switch (enemyType)
			{
				case EnemyType.Asteroid:
					InstantiateAt(GameAssetKeys.Asteroid, position);
					break;

				case EnemyType.AsteroidPiece:
					InstantiateAt(GameAssetKeys.AsteroidPiece, position);
					break;

				case EnemyType.Ufo:
					InstantiateAt(GameAssetKeys.Ufo, position);
					break;

				default:
					throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, null);
			}
		}

		public void CreateBullet(Vector2 position)
		{
			InstantiateAt(GameAssetKeys.Player, position);
		}

		private void InstantiateAt(string assetKey, Vector2 position)
		{
			GameObject gameObject = _prefabCreator.Instantiate(assetKey);
			gameObject.transform.position = position;
		}
	}
}