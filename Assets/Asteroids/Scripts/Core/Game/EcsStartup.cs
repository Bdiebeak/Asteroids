using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories.Systems;
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
		private readonly ISystemsFactory _systemsFactory;

		public EcsStartup(InputContext inputContext, GameplayContext gameplayContext,
						  ISystemsFactory systemsFactory)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_systemsFactory = systemsFactory;
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
			_inputSystems.Add(new InputFeatures(_systemsFactory));
#if UNITY_EDITOR
			_inputSystems.Add(new UnityDebugFeature(_inputContext));
#endif
		}

		private void InitializeGameplaySystems()
		{
			_gameplaySystems = new SystemsContainer();
			_gameplaySystems.Add(new GameplayFeatures(_systemsFactory));
#if UNITY_EDITOR
			_gameplaySystems.Add(new UnityDebugFeature(_gameplayContext));
#endif
		}
	}
}