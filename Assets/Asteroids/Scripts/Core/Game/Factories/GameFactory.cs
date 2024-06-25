using System;
using Asteroids.Scripts.Core.Game.Features.Enemies;
using Asteroids.Scripts.Core.Utilities.Services.Assets;
using Asteroids.Scripts.DI.Container;
using Asteroids.Scripts.DI.Extensions;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Factories
{
	public class GameFactory : IGameFactory
	{
		private readonly IContainer _container;
		private readonly IAssetProvider _assetProvider;

		public GameFactory(IContainer container, IAssetProvider assetProvider)
		{
			_container = container;
			_assetProvider = assetProvider;
		}

		public Camera CreateMainCamera()
		{
			GameObject cameraObject = Instantiate(GameAssetKeys.MainCamera);
			return cameraObject.GetComponent<Camera>();
		}

		public void CreatePlayer(Vector2 position)
		{
			Instantiate(GameAssetKeys.Player, position);
		}

		public void CreateEnemy(EnemyType enemyType, Vector2 position)
		{
			switch (enemyType)
			{
				case EnemyType.Asteroid:
					Instantiate(GameAssetKeys.Asteroid, position);
					break;

				case EnemyType.AsteroidPiece:
					Instantiate(GameAssetKeys.AsteroidPiece, position);
					break;

				case EnemyType.Ufo:
					Instantiate(GameAssetKeys.Ufo, position);
					break;

				default:
					throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, null);
			}
		}

		public void CreateBullet(Vector2 position, float rotation)
		{
			Instantiate(GameAssetKeys.Bullet, position, rotation);
		}

		private GameObject Instantiate(string assetKey)
		{
			GameObject prefab = _assetProvider.Load<GameObject>(assetKey);
			return _container.InstantiatePrefab(prefab);
		}

		private GameObject Instantiate(string assetKey, Vector2 position)
		{
			GameObject prefab = _assetProvider.Load<GameObject>(assetKey);
			return _container.InstantiatePrefab(prefab, position, Quaternion.identity);
		}

		private GameObject Instantiate(string assetKey, Vector2 position, float rotation)
		{
			GameObject prefab = _assetProvider.Load<GameObject>(assetKey);
			return _container.InstantiatePrefab(prefab, position, Quaternion.Euler(0, 0, rotation));
		}
	}
}