using System.Linq;
using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Enemies.Components;
using Asteroids.Scripts.Core.Game.Features.Enemies.Requests;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.Game.Features.Score.Components;
using Asteroids.Scripts.Core.Game.Features.WorldBounds.Components;
using Asteroids.Scripts.Core.Utilities.Services.Configs;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Requests;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Enemies.Systems
{
	public class HandleSpawnUfoRequestSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly IGameFactory _gameFactory;
		private readonly IConfigService _configService;
		private readonly Mask _playerMask;

		public HandleSpawnUfoRequestSystem(GameplayContext gameplayContext,
										   IGameFactory gameFactory, IConfigService configService)
		{
			_gameplayContext = gameplayContext;
			_gameFactory = gameFactory;
			_configService = configService;
			_playerMask = new Mask().Include<PlayerComponent>();
		}

		public void Update()
		{
			var requestEntities = _gameplayContext.GetRequests<SpawnUfoRequest>();
			var playerEntities = _gameplayContext.GetEntities(_playerMask);
			foreach (Entity entity in requestEntities)
			{
				SpawnUfoRequest request = entity.Get<SpawnUfoRequest>();

				Entity ufo = _gameplayContext.CreateEntity();
				ufo.Add(new EnemyComponent());
				ufo.Add(new UfoComponent());
				ufo.Add(new PositionComponent()).value = request.position;
				ufo.Add(new MoveDirectionComponent());
				ufo.Add(new MoveSpeedComponent()).value = _configService.UfoConfig.speed;
				ufo.Add(new MoveVelocityComponent());
				ufo.Add(new KeepInBoundsComponent());
				ufo.Add(new ChaseTargetComponent()).targetEntityId = playerEntities.First().Id;
				ufo.Add(new ScoreRewardComponent()).value = _configService.UfoConfig.score;
				_gameFactory.CreateUfoView(ufo);
			}

			_gameplayContext.DestroyRequests<SpawnUfoRequest>();
		}
	}
}