using Asteroids.Scripts.Core.Game.Behaviours;
using Asteroids.Scripts.Core.Utilities.Services.Assets;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Entities;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Factories
{
	public class GameFactory : IGameFactory
	{
		private readonly IAssetProvider _assetProvider;
		private readonly IEntityFactory _entityFactory;
		private readonly IViewFactory _viewFactory;

		public GameFactory(IAssetProvider assetProvider, IEntityFactory entityFactory, IViewFactory viewFactory)
		{
			_assetProvider = assetProvider;
			_entityFactory = entityFactory;
			_viewFactory = viewFactory;
		}

		public Camera CreateMainCamera()
		{
			GameObject prefab = _assetProvider.Load<GameObject>(GameAssetKeys.MainCamera);
			GameObject instance = Object.Instantiate(prefab);
			return instance.GetComponent<Camera>();
		}

		public void CreatePlayer(Vector2 position)
		{
			Entity entity = _entityFactory.CreatePlayer(position, PlayerConfig.MoveSpeed,
														PlayerConfig.RotationSpeed, PlayerConfig.Acceleration,
														PlayerConfig.Deceleration, WeaponsConfig.LaserCharges);
			EntityView view = _viewFactory.CreateView(GameAssetKeys.Player, position);
			view.Construct(entity);
		}

		public void CreateAsteroid(Vector2 position)
		{
			Entity entity = _entityFactory.CreateAsteroid(position, Random.insideUnitCircle,
														  EnemiesConfig.AsteroidSpeed, EnemiesConfig.AsteroidScore);
			EntityView view = _viewFactory.CreateView(GameAssetKeys.Asteroid, position);
			view.Construct(entity);
		}

		public void CreateAsteroidPiece(Vector2 position)
		{
			Entity entity = _entityFactory.CreateAsteroidPiece(position, Random.insideUnitCircle,
															   EnemiesConfig.AsteroidPieceSpeed, EnemiesConfig.AsteroidPieceScore);
			EntityView view = _viewFactory.CreateView(GameAssetKeys.AsteroidPiece, position);
			view.Construct(entity);
		}

		public void CreateUfo(Vector2 position)
		{
			Entity entity = _entityFactory.CreateUfo(position, EnemiesConfig.UfoSpeed, EnemiesConfig.UfoScore);
			EntityView view = _viewFactory.CreateView(GameAssetKeys.Ufo, position);
			view.Construct(entity);
		}

		public void CreateBullet(Vector2 position, Vector2 direction)
		{
			Entity entity = _entityFactory.CreateBullet(position, direction, WeaponsConfig.BulletSpeed);
			EntityView view = _viewFactory.CreateView(GameAssetKeys.Bullet, position);
			view.Construct(entity);
		}

		public void CreateLaser(Vector2 position, float rotation, Entity shooter, float destroyTime)
		{
			Entity entity = _entityFactory.CreateLaser(position, rotation, shooter, destroyTime);
			EntityView view = _viewFactory.CreateView(GameAssetKeys.Laser, position, rotation);
			view.Construct(entity);
		}
	}
}