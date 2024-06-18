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

		public Camera CreateMainCamera()
		{
			return _prefabCreator.InstantiateComponent<Camera>(AssetKeys.MainCamera);
		}

		public void CreatePlayer()
		{
			_prefabCreator.Instantiate(AssetKeys.Player);
		}

		public void CreateEnemy(EnemyType enemyType)
		{
			// TODO: don't like enum and switch.
			switch (enemyType)
			{
				case EnemyType.Asteroid:
					_prefabCreator.Instantiate(AssetKeys.Asteroid);
					break;

				case EnemyType.AsteroidPiece:
					_prefabCreator.Instantiate(AssetKeys.AsteroidPiece);
					break;

				case EnemyType.Ufo:
					_prefabCreator.Instantiate(AssetKeys.Ufo);
					break;

				default:
					throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, null);
			}
		}
	}
}