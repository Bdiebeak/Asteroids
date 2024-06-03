using System.Collections.Generic;
using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Extensions;
using Asteroids.Scripts.DI.Resolver;
using Asteroids.Scripts.Logic.Infrastructure.StateMachine;
using Asteroids.Scripts.Logic.Infrastructure.StateMachine.States;
using Asteroids.Scripts.Unity.Infrastructure.Installers;
using UnityEngine;

namespace Asteroids.Scripts.Unity.Infrastructure
{
	public class GameRunner : MonoBehaviour
	{
		[SerializeField]
		private List<MonoInstaller> monoInstallers;

		private IContainerResolver _diContainer;
		private IGameStateMachine _gameStateMachine;

		private void Awake()
		{
			_diContainer = BuildContainer();
			_gameStateMachine = _diContainer.Resolve<IGameStateMachine>();
		}

		private void Start()
		{
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

		private IContainerResolver BuildContainer()
		{
			IContainerBuilder containerBuilder = new ContainerBuilder();
			foreach (MonoInstaller installer in monoInstallers)
			{
				installer.InstallTo(containerBuilder);
			}
			containerBuilder.Register(new GameStateMachineInstaller());
			return containerBuilder.Build();
		}
	}
}