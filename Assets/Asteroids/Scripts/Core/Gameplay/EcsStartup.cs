using Asteroids.Scripts.Core.Gameplay.Collisions.Systems;
using Asteroids.Scripts.Core.Gameplay.Contexts;
using Asteroids.Scripts.Core.Gameplay.Enemies.Systems;
using Asteroids.Scripts.Core.Gameplay.Input;
using Asteroids.Scripts.Core.Gameplay.Movement;
using Asteroids.Scripts.Core.Gameplay.Player;
using Asteroids.Scripts.Core.Gameplay.UI.Systems;
using Asteroids.Scripts.Core.Infrastructure.Factories;
using Asteroids.Scripts.Core.Infrastructure.Services.Input;
using Asteroids.Scripts.Core.Infrastructure.Services.Time;
using Asteroids.Scripts.Core.Infrastructure.StateMachine;
using Asteroids.Scripts.Core.UI.Models;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Gameplay
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

		public EcsStartup(InputContext inputContext, GameplayContext gameplayContext,
						  IInputService inputService, IGameFactory gameFactory, ITimeService timeService,
						  GameScreenModel gameScreenModel, IGameStateMachine gameStateMachine)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_inputService = inputService;
			_gameFactory = gameFactory;
			_timeService = timeService;
			_gameScreenModel = gameScreenModel;
			_gameStateMachine = gameStateMachine;
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
			_gameplaySystems.Add(new MovementFeature(_inputContext, _gameplayContext, _timeService))
							.Add(new SpawnEnemySystem(_gameFactory))
							.Add(new PlayerCollisionSystem(_gameplayContext, _gameStateMachine))
							.Add(new UpdateGameScreenModelSystem(_gameplayContext, _gameScreenModel))
							.Add(new CleanUpCollisionEventsSystem(_gameplayContext));
		}
	}
}