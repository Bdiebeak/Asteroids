using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Features.KeepInScreen.Systems;
using Asteroids.Scripts.Core.Infrastructure.Services.Camera;
using Asteroids.Scripts.ECS.Systems;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Game.Features.KeepInScreen
{
	public class KeepInScreenFeature : Feature
	{
		private readonly GameplayContext _gameplayContext;
		private readonly ICameraProvider _cameraProvider;

		public KeepInScreenFeature(GameplayContext gameplayContext, ICameraProvider cameraProvider)
		{
			_gameplayContext = gameplayContext;
			_cameraProvider = cameraProvider;
		}

		public override void AddTo(SystemsContainer systems)
		{
			systems.Add(new KeepInScreenSystem(_gameplayContext, _cameraProvider));
		}
	}
}