using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Player.Requests;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Player.Systems
{
	public class SpawnPlayerSystem : IStartSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IConfigService _configService;

		public SpawnPlayerSystem(GameplayContext gameplayContext, IConfigService configService)
		{
			_gameplayContext = gameplayContext;
			_configService = configService;
		}

		public void Start()
		{
			PlayerConfig playerConfig = _configService.PlayerConfig;
			_gameplayContext.CreateRequest(new SpawnPlayerRequest
			{
				position = playerConfig.spawnPoint
			});
		}
	}
}