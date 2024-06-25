using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Systems.Interfaces;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game.Features.Player.Systems
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
			_gameFactory.CreatePlayer(PlayerConfig.spawnPosition);
		}
	}
}