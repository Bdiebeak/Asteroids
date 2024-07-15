using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features;
using Asteroids.Scripts.ECS.Features;
using Asteroids.Scripts.ECS.Systems.Container;
using Asteroids.Scripts.ECS.Unity.Debug;

namespace Asteroids.Scripts.Core.Game
{
	public class EcsStartup
	{
		private SystemsContainer _inputSystems;
		private SystemsContainer _gameplaySystems;
		private readonly InputContext _inputContext;
		private readonly GameplayContext _gameplayContext;
		private readonly ISystemFactory _systemFactory;

		public EcsStartup(InputContext inputContext, GameplayContext gameplayContext,
						  ISystemFactory systemFactory)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_systemFactory = systemFactory;
		}

		public void Initialize()
		{
			InitializeInputSystems();
			InitializeGameplaySystems();
		}

		public void Start()
		{
			_inputSystems?.Start();
			_gameplaySystems?.Start();
		}

		public void Update()
		{
			_inputSystems?.Update();
			_gameplaySystems?.Update();
		}

		public void CleanUp()
		{
			_inputSystems?.CleanUp();
			_gameplaySystems?.CleanUp();
		}

		public void Destroy()
		{
			_inputSystems?.Destroy();
			_inputSystems = null;
			_gameplaySystems?.Destroy();
			_gameplaySystems = null;
			_inputContext.Destroy();
			_gameplayContext.Destroy();
		}

		private void InitializeInputSystems()
		{
			_inputSystems = new SystemsContainer();
#if UNITY_EDITOR
			_inputSystems.Add(new UnityDebugFeature(_inputContext));
#endif
			_inputSystems.Add(new InputFeatures(_systemFactory));
		}

		private void InitializeGameplaySystems()
		{
			_gameplaySystems = new SystemsContainer();
#if UNITY_EDITOR
			_gameplaySystems.Add(new UnityDebugFeature(_gameplayContext));
#endif
			_gameplaySystems.Add(new GameplayFeatures(_systemFactory));
		}
	}
}