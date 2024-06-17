using System;
using Asteroids.Scripts.Core.Gameplay.Enemies;
using Asteroids.Scripts.Core.Gameplay.View;
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

		public IView CreatePlayer()
		{
			return _prefabCreator.InstantiateComponent<IView>(AssetKeys.Player);
		}

		public IView CreateEnemy(EnemyType enemyType)
		{
			// TODO: don't like enum and switch.
			switch (enemyType)
			{
				case EnemyType.Asteroid:
					return _prefabCreator.InstantiateComponent<IView>(AssetKeys.Asteroid);

				case EnemyType.AsteroidPiece:
					return _prefabCreator.InstantiateComponent<IView>(AssetKeys.AsteroidPiece);

				case EnemyType.Ufo:
					return _prefabCreator.InstantiateComponent<IView>(AssetKeys.Ufo);

				default:
					throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, null);
			}
		}
	}
}