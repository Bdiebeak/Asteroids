using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Player.Requests;
using Asteroids.Scripts.Core.Game.Requests;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Player.Systems
{
	public class SpawnPlayerSystem : IStartSystem
	{
		private readonly GameplayContext _gameplayContext;

		public SpawnPlayerSystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
		}

		public void Start()
		{
			_gameplayContext.CreateRequest(new SpawnPlayerRequest
			{
				position = PlayerConfig.SpawnPosition
			});
		}
	}
}