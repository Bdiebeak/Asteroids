using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.Movement.Components;
using Asteroids.Scripts.Core.Game.Features.Player.Components;
using Asteroids.Scripts.Core.UI.Models;
using Asteroids.Scripts.ECS.Components;
using Asteroids.Scripts.ECS.Entities;
using Asteroids.Scripts.ECS.Systems.Interfaces;

namespace Asteroids.Scripts.Core.Game.Features.UI.Systems
{
	public class UpdateGameScreenSystem : IUpdateSystem
	{
		private readonly GameplayContext _gameplayContext;
		private readonly GameScreenModel _gameScreenModel;
		private readonly Mask _mask;

		public UpdateGameScreenSystem(GameplayContext gameplayContext, GameScreenModel gameScreenModel)
		{
			_gameplayContext = gameplayContext;
			_gameScreenModel = gameScreenModel;
			_mask = new Mask().Include<PlayerMarker>();
		}

		public void Update()
		{
			var entities = _gameplayContext.GetEntities(_mask);
			foreach (Entity entity in entities)
			{
				_gameScreenModel.position = entity.Get<Position>().value;
				_gameScreenModel.rotation = entity.Get<Rotation>().value;
				_gameScreenModel.velocity = entity.Get<Velocity>().value;
				_gameScreenModel.velocityMagnitude = entity.Get<Velocity>().value.magnitude;
			}
		}
	}
}