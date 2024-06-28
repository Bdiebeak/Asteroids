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
		private readonly Mask _toDestroyMask;

		public DestroySystem(GameplayContext gameplayContext)
		{
			_gameplayContext = gameplayContext;
			_toDestroyMask = new Mask().Include<ToDestroy>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_toDestroyMask);
			foreach (Entity entity in entities)
			{
				_gameplayContext.DestroyEntity(entity);
			}
		}
	}
}