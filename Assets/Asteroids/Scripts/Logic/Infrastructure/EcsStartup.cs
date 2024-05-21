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
		private ISystemsContainer _physicSystems;

		public void Initialize(IInputService inputService, IViewFactory viewFactory)
		{
			// TODO: do i need it?
			// Initialize contexts.
			// _contexts = new ContextsContainer();
			// _contexts.Add(ContextTypes.Input, new Context());
			// _contexts.Add(ContextTypes.Gameplay, new Context());
			// _contexts.Add(ContextTypes.Physics, new Context());

			// Initialize contexts.
			_inputContext = new Context();
			_gameplayContext = new Context();

			// Initialize input systems.
			_inputSystems = new SystemsContainer();
			_inputSystems.Add(new InitializeInputSystem(_inputContext))
						 .Add(new UpdateMoveInputSystem(_inputContext, inputService))
						 .Add(new UpdateAttackInputSystem(_inputContext, inputService))
						 .Add(new ApplyMoveInputSystem(_inputContext, _gameplayContext))
						 .Add(new ApplyAttackInputSystem(_inputContext, _gameplayContext));

			// Initialize gameplay systems.
			_gameplaySystems = new SystemsContainer();
			// TODO: mb move and rotation in physics?
			_gameplaySystems.Add(new InitializePlayerSystem(_gameplayContext, viewFactory))
							.Add(new MoveSystem(_gameplayContext))
							.Add(new RotateSystem(_gameplayContext))
							.Add(new UpdateViewSystem(_gameplayContext));

			// Initialize physics systems.
			_physicSystems = new SystemsContainer();
		}

		public void Start()
		{
			_inputSystems.Start();
			_gameplaySystems.Start();
			_physicSystems.Start();
		}

		public void Update(float deltaTime)
		{
			_inputSystems.Update(deltaTime);
			_gameplaySystems.Update(deltaTime);
		}

		public void FixedUpdate(float fixedTime)
		{
			_physicSystems.Update(fixedTime);
		}

		public void CleanUp()
		{
			// TODO: mb clean after update of every systems?
			_inputSystems.CleanUp();
			_gameplaySystems.CleanUp();
			_physicSystems.CleanUp();
		}

		public void Stop()
		{
			_inputSystems.Stop();
			_gameplaySystems.Stop();
			_physicSystems.Stop();
		}
	}
}