using Asteroids.Scripts.ECS.Entities;

namespace Asteroids.Scripts.Core.Game.Factories
{
	public interface IGameFactory
	{
		void CreatePlayerView(Entity entity);
		void CreateAsteroidView(Entity entity);
		void CreateAsteroidPieceView(Entity entity);
		void CreateUfoView(Entity entity);
		void CreateBulletView(Entity entity);
		void CreateLaserView(Entity entity);
	}
}