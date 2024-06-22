using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.UI.Systems;
using Asteroids.Scripts.Core.UI.Models;
using Asteroids.Scripts.ECS.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.UI
{
	public class UIFeature : Feature
	{
		private readonly GameplayContext _gameplayContext;
		private readonly GameScreenModel _gameScreenModel;

		public UIFeature(GameplayContext gameplayContext, GameScreenModel gameScreenModel)
		{
			_gameplayContext = gameplayContext;
			_gameScreenModel = gameScreenModel;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(new UpdateGameScreenSystem(_gameplayContext, _gameScreenModel));
		}
	}
}