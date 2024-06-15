using Asteroids.Scripts.Core.Gameplay.Input;
using Asteroids.Scripts.Core.Gameplay.Movement;
using Asteroids.Scripts.Core.Gameplay.Movement.Systems;
using Asteroids.Scripts.Core.Gameplay.Player.Systems;
using Asteroids.Scripts.Core.Gameplay.View.Systems;
using Asteroids.Scripts.Core.Infrastructure.Factories;
using Asteroids.Scripts.Core.Infrastructure.Services.Input;
using Asteroids.Scripts.Core.Infrastructure.Services.Time;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Gameplay
{
	public class EcsStartup
	{
		private IContext _inputContext;
		private IContext _gameplayContext;
		private SystemsContainer _inputSystems;
		private SystemsContainer _gameplaySystems;
		private readonly IInputService _inputService;
		private readonly IGameFactory _gameFactory;
		private readonly ITimeService _timeService;

		public EcsStartup(IInputService inputService, IGameFactory gameFactory,
						  ITimeService timeService)
		{
			_inputService = inputService;
			_gameFactory = gameFactory;
			_timeService = timeService;
		}

		// TODO: services with DiContainer, factory for systems.
		// TODO: but how to split few Context on different bindings - Contexts { inputContext, gameplayContext }
		public void Initialize()
		{
			// Initialize contexts.
			_inputContext = new Context();
			_gameplayContext = new Context();

			// Initialize input systems.
			_inputSystems = new SystemsContainer();
			_inputSystems.Add(new InputFeature(_inputContext, _gameplayContext, _inputService, _timeService));

			// Initialize gameplay systems.
			_gameplaySystems = new SystemsContainer();
			_gameplaySystems.Add(new InitializePlayerSystem(_gameplayContext, _gameFactory))
							.Add(new MovementFeature(_gameplayContext, _timeService))
							.Add(new UpdateViewSystem(_gameplayContext));
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
		}
	}
}