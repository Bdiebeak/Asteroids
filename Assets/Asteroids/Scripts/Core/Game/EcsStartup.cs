using Asteroids.Scripts.Core.Game.Contexts;
using Asteroids.Scripts.Core.Game.Factories;
using Asteroids.Scripts.Core.Game.Features.Collision;
using Asteroids.Scripts.Core.Game.Features.Collision.Systems;
using Asteroids.Scripts.Core.Game.Features.Input;
using Asteroids.Scripts.Core.Game.Features.Movement;
using Asteroids.Scripts.Core.Game.Features.Spawn;
using Asteroids.Scripts.Core.Game.Features.UI.Systems;
using Asteroids.Scripts.Core.Game.Features.Wrapper.Systems;
using Asteroids.Scripts.Core.Infrastructure.Services.Input;
using Asteroids.Scripts.Core.Infrastructure.Services.Time;
using Asteroids.Scripts.Core.Infrastructure.StateMachine;
using Asteroids.Scripts.Core.UI.Models;
using Asteroids.Scripts.ECS.Systems.Container;
using UnityEngine;

namespace Asteroids.Scripts.Core.Game
{
	public class EcsStartup
	{
		private SystemsContainer _inputSystems;
		private SystemsContainer _gameplaySystems;
		private readonly InputContext _inputContext;
		private readonly GameplayContext _gameplayContext;
		private readonly IInputService _inputService;
		private readonly IGameFactory _gameFactory;
		private readonly ITimeService _timeService;
		private readonly GameScreenModel _gameScreenModel;
		private readonly IGameStateMachine _gameStateMachine;
		private readonly Camera _camera;

		// TODO: Don't like huge constructor here. Create some SystemFactory or smth.
		public EcsStartup(InputContext inputContext, GameplayContext gameplayContext,
						  IInputService inputService, IGameFactory gameFactory, ITimeService timeService,
						  GameScreenModel gameScreenModel, IGameStateMachine gameStateMachine,
						  Camera camera)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_inputService = inputService;
			_gameFactory = gameFactory;
			_timeService = timeService;
			_gameScreenModel = gameScreenModel;
			_gameStateMachine = gameStateMachine;
			_camera = camera;
		}

		public void Initialize()
		{
			InitializeInputSystems();
			InitializeGameplaySystems();
		}

		public void Start()
		{
			_inputSystems.Start();
			_gameplaySystems.Start();
		}

		public void Update()
		{
			_inputSystems.Update();
			_gameplaySystems.Update();
		}

		public void CleanUp()
		{
			_inputSystems.CleanUp();
			_gameplaySystems.CleanUp();
		}

		public void Stop()
		{
			_inputSystems.Stop();
			_gameplaySystems.Stop();
			_inputContext.Destroy();
			_gameplayContext.Destroy();
		}

		private void InitializeInputSystems()
		{
			_inputSystems = new SystemsContainer();
			_inputSystems.Add(new InputFeature(_inputContext, _inputService));
		}

		private void InitializeGameplaySystems()
		{
			_gameplaySystems = new SystemsContainer();
			_gameplaySystems.Add(new SpawnFeature(_gameFactory));
			_gameplaySystems.Add(new MovementFeature(_inputContext, _gameplayContext, _timeService));
			_gameplaySystems.Add(new KeepInScreenSystem(_gameplayContext, _camera));
			_gameplaySystems.Add(new CollisionFeature(_gameplayContext, _gameStateMachine));
			_gameplaySystems.Add(new UpdateGameScreenSystem(_gameplayContext, _gameScreenModel));
			_gameplaySystems.Add(new CleanUpCollisionEventsSystem(_gameplayContext));
		}
	}
}