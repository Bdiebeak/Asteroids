using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features;
using Asteroids.Scripts.Core.Game.Features.Base;
using Asteroids.Scripts.ECS.Systems.Container;
using Asteroids.Scripts.ECS.Unity.Debug;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game
{
	public class EcsStartup
	{
		private SystemsContainer _inputSystems;
		private SystemsContainer _gameplaySystems;
		private GameObject _debugObject;
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
			InitializeDebug();
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
			if (_inputSystems != null)
			{
				_inputSystems.Destroy();
				_inputSystems = null;
			}
			if (_gameplaySystems != null)
			{
				_gameplaySystems.Destroy();
				_gameplaySystems = null;
			}
			_inputContext.Destroy();
			_gameplayContext.Destroy();
			Object.Destroy(_debugObject); // TODO: don't like this work with debug
		}

		private void InitializeInputSystems()
		{
			_inputSystems = new SystemsContainer();
			_inputSystems.Add(new InputFeatures(_systemsFactory));
		}

		private void InitializeGameplaySystems()
		{
			_gameplaySystems = new SystemsContainer();
			_gameplaySystems.Add(new GameplayFeatures(_systemsFactory));
		}

		private void InitializeDebug()
		{
			_debugObject = new GameObject("EcsDebug");
			Object.DontDestroyOnLoad(_debugObject);

			_debugObject.AddComponent<ContextDrawer>().Initialize(_inputContext, _debugObject.transform);
			_debugObject.AddComponent<ContextDrawer>().Initialize(_gameplayContext, _debugObject.transform);
		}
	}
}