﻿using Asteroids.Scripts.Core.Infrastructure.Installers;
using Asteroids.Scripts.Core.Infrastructure.StateMachine;
using Asteroids.Scripts.Core.Infrastructure.StateMachine.States;
using Asteroids.Scripts.DI.Builder;
using Asteroids.Scripts.DI.Extensions;
using Asteroids.Scripts.DI.Resolver;
using UnityEngine;

namespace Asteroids.Scripts.Core.Infrastructure
{
	// TODO: IEngineCycleBroadcaster - broadcasts engine events (Start, Update and etc.)
	// TODO: IEnginePhysicsBroadcaster - broadcasts engine physics events (OnCollisionEnter and etc.)
	public class GameRunner : MonoBehaviour
	{
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
			containerBuilder.Register(new ServicesInstaller());
			containerBuilder.Register(new GameStateMachineInstaller());
			return containerBuilder.Build();
		}
	}
}