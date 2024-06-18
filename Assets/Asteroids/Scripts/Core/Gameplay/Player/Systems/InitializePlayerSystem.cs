using Asteroids.Scripts.Core.Infrastructure.Factories;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Gameplay.Player.Systems
{
	public class InitializePlayerSystem : IStartSystem
	{
		private readonly IGameFactory _gameFactory;

		public InitializePlayerSystem(IGameFactory gameFactory)
		{
			_gameFactory = gameFactory;
		}

		public void Start()
		{
			_gameFactory.CreatePlayer();
		}
	}
}