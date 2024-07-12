using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Destroy.Components;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.Destroy.Systems
{
	public class DestroySystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly Mask _destroyMask;

		public DestroySystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_destroyMask = new Mask().Include<ToDestroyComponent>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_destroyMask);
			foreach (Entity entity in entities)
			{
				_gameplayContext.DestroyEntity(entity);
			}
		}
	}
}