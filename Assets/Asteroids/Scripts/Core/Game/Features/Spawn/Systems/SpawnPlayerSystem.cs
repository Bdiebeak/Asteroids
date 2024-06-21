using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Spawn.Systems
{
	public class SpawnPlayerSystem : IStartSystem
	{
		private readonly IGameFactory _gameFactory;

		public SpawnPlayerSystem(IGameFactory gameFactory)
		{
			_gameFactory = gameFactory;
		}

		public void Start()
		{
			_gameFactory.CreatePlayer(Vector2.zero);
		}
	}
}