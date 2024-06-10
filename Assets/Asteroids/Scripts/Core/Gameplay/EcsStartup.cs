using Asteroids.Scripts.Core.Gameplay.Input;
using Asteroids.Scripts.Core.Gameplay.Movement.Systems;
using Asteroids.Scripts.Core.Gameplay.Player.Systems;
using Asteroids.Scripts.Core.Gameplay.View.Systems;
using Asteroids.Scripts.Core.Infrastructure.Factories;
using Asteroids.Scripts.Core.Infrastructure.Services;
using Asteroids.Scripts.Core.Infrastructure.Services.Input;
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

		// TODO: services with DiContainer, factory for systems.
		// TODO: but how to split Context on different binding - Tags?
		public void Initialize(IInputService inputService, IViewFactory viewFactory)
		{
			// Initialize contexts.
			_inputContext = new Context();
			_gameplayContext = new Context();

			// Initialize input systems.
			_inputSystems = new SystemsContainer();
			_inputSystems.Add(new InputFeature(_inputContext, _gameplayContext, inputService));

			// Initialize gameplay systems.
			_gameplaySystems = new SystemsContainer();
			_gameplaySystems.Add(new InitializePlayerSystem(_gameplayContext, viewFactory))
							.Add(new MoveSystem(_gameplayContext))
							.Add(new RotateSystem(_gameplayContext))
							.Add(new UpdateViewSystem(_gameplayContext));
		}

		public void InitializeDebug(IEcsDebugger ecsDebugger)
		{
			ecsDebugger.SetContexts(_inputContext, _gameplayContext);
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