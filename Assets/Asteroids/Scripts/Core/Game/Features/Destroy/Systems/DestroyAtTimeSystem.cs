using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.Core.Utilities.Services.Time;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Destroy.Systems
{
	public class DestroyAtTimeSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ITimeService _timeService;
		private readonly Mask _mask;

		public DestroyAtTimeSystem(GameplayContext gameplayContext, ITimeService timeService)
		{
			_gameplayContext = gameplayContext;
			_timeService = timeService;
			_mask = new Mask().Include<DestroyAtTimeComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				DestroyAtTimeComponent destroyAtTime = entity.Get<DestroyAtTimeComponent>();
				if (_timeService.Time < destroyAtTime.value)
				{
					// Wait while current time will be greater than the time of destroy.
					continue;
				}

				_gameplayContext.CreateEntity().Add(new DestroyRequestComponent()).target = entity;
			}
		}
	}
}