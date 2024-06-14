using Asteroids.Scripts.Core.Gameplay.Input;
using Asteroids.Scripts.Core.Gameplay.Movement.Systems;
using Asteroids.Scripts.Core.Gameplay.Player.Systems;
using Asteroids.Scripts.Core.Gameplay.View.Systems;
using Asteroids.Scripts.Core.Infrastructure.Factories;
using Asteroids.Scripts.Core.Infrastructure.Services.Input;
using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Systems.Container;

namespace Asteroids.Scripts.Core.Gameplay
{
	public class EcsStartup
	{
		private readonly IInputService _inputService;
		private readonly IGameFactory _gameFactory;

		private IContext _inputContext;
		private IContext _gameplayContext;
		private SystemsContainer _inputSystems;
		private SystemsContainer _gameplaySystems;

		public EcsStartup(IInputService inputService, IGameFactory gameFactory)
		{
			_inputService = inputService;
			_gameFactory = gameFactory;
		}

		// TODO: services with DiContainer, factory for systems.
		// TODO: but how to split Context on different binding - Tags?
		public void Initialize()
		{
			// Initialize contexts.
			_inputContext = new Context();
			_gameplayContext = new Context();

			// Initialize input systems.
			_inputSystems = new SystemsContainer();
			_inputSystems.Add(new InputFeature(_inputContext, _gameplayContext, _inputService));

			// Initialize gameplay systems.
			_gameplaySystems = new SystemsContainer();
			_gameplaySystems.Add(new InitializePlayerSystem(_gameplayContext, _gameFactory))
							.Add(new MoveSystem(_gameplayContext))
							.Add(new RotateSystem(_gameplayContext))
							.Add(new UpdateViewSystem(_gameplayContext));
		}

		public void Start()
		{
			_inputSystems.Start();
			_gameplaySystems.Start();
		}

		public void Update(float deltaTime)
		{
			_inputSystems.Update(deltaTime);
			_gameplaySystems.Update(deltaTime);
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