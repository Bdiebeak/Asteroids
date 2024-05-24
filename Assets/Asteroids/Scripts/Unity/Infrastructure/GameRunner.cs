using Asteroids.Scripts.DI;
using Asteroids.Scripts.Logic.Infrastructure;
using Asteroids.Scripts.Logic.Infrastructure.Services;
using Asteroids.Scripts.Logic.Infrastructure.StateMachine;
using Asteroids.Scripts.Logic.Infrastructure.StateMachine.States;
using Asteroids.Scripts.Unity.Infrastructure.Services;
using UnityEngine;

namespace Asteroids.Scripts.Unity
{
	public class GameRunner : MonoBehaviour
	{
		public ViewFactory viewFactory;

		private IServiceProvider _serviceProvider;
		private IGameStateMachine _gameStateMachine;

		private void Awake()
		{
			InitializeServiceProvider();
			InitializeStateMachine();
			_gameStateMachine.Enter<BootstrapState>();
		}

		private void Update()
		{
			_gameStateMachine.Update();
		}

		private void OnDestroy()
		{
			_gameStateMachine.Exit();
		}

		private void InitializeServiceProvider()
		{
			_serviceProvider = new ServiceProvider();
			_serviceProvider.Bind<IInputService>(new UnityInputService());
			_serviceProvider.Bind<IViewFactory>(viewFactory);
			_serviceProvider.Bind<EcsStartup>(new EcsStartup());
		}

		private void InitializeStateMachine()
		{
			_gameStateMachine = new GameStateMachine();
			_gameStateMachine.Register(new BootstrapState(_gameStateMachine));
			_gameStateMachine.Register(new GameInitializeState(_gameStateMachine,
															   _serviceProvider.Resolve<EcsStartup>(),
															   _serviceProvider.Resolve<IInputService>(),
															   _serviceProvider.Resolve<IViewFactory>()));
			_gameStateMachine.Register(new GameLoopState(_gameStateMachine,
														 _serviceProvider.Resolve<EcsStartup>()));
			_gameStateMachine.Register(new GameRestartState(_gameStateMachine));
		}
	}
}