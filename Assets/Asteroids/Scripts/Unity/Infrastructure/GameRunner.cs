using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Container;
using Asteroids.Scripts.DI.Extensions;
using Asteroids.Scripts.Logic.Infrastructure.StateMachine;
using Asteroids.Scripts.Logic.Infrastructure.StateMachine.States;
using UnityEngine;

namespace Asteroids.Scripts.Unity
{
	public class GameRunner : MonoBehaviour
	{
		private IContainer _diContainer;
		private IGameStateMachine _gameStateMachine;

		private void Awake()
		{
			_diContainer = BuildContainer();
		}

		private void Start()
		{
			_gameStateMachine = _diContainer.Resolve<IGameStateMachine>();
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

		private IContainer BuildContainer()
		{
			IContainerBuilder containerBuilder = new ContainerBuilder();
			containerBuilder.Register(new ServicesInstaller());
			containerBuilder.Register(new GameStateMachineInstaller());
			return containerBuilder.Build();
		}
	}
}