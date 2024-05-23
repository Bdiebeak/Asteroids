using Asteroids.Scripts.ECS.Contexts;
using Asteroids.Scripts.ECS.Systems.Container;
using Asteroids.Scripts.Logic.Infrastructure.Services;
using Asteroids.Scripts.Logic.Systems;
using Asteroids.Scripts.Logic.Systems.Input;
using Asteroids.Scripts.Logic.Systems.Movement;

namespace Asteroids.Scripts.Logic.Infrastructure
{
	public class EcsStartup
	{
		private IContext _inputContext;
		private IContext _gameplayContext;

		private ISystemsContainer _inputSystems;
		private ISystemsContainer _gameplaySystems;

		// TODO: services with DiContainer, factory for systems.
		public void Initialize(IInputService inputService, IViewFactory viewFactory)
		{
			// Initialize contexts.
			_inputContext = new Context();
			_gameplayContext = new Context();

			// Initialize input systems.
			_inputSystems = new SystemsContainer();
			// TODO: use Features and split this initialization.
			_inputSystems.Add(new InitializeInputSystem(_inputContext))
						 .Add(new UpdateMoveInputSystem(_inputContext, inputService))
						 .Add(new UpdateAttackInputSystem(_inputContext, inputService))
						 .Add(new ApplyMoveInputSystem(_inputContext, _gameplayContext))
						 .Add(new ApplyAttackInputSystem(_inputContext, _gameplayContext));

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