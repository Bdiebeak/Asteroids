﻿using Asteroids.Scripts.Core.Gameplay.Input;
using Asteroids.Scripts.Core.Gameplay.Movement;
using Asteroids.Scripts.Core.Gameplay.Player.Systems;
using Asteroids.Scripts.Core.Infrastructure.Factories;
using Asteroids.Scripts.Core.Infrastructure.Services.Input;
using Asteroids.Scripts.Core.Infrastructure.Services.Time;
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

		public EcsStartup(InputContext inputContext, GameplayContext gameplayContext,
						  IInputService inputService, IGameFactory gameFactory, ITimeService timeService)
		{
			_inputContext = inputContext;
			_gameplayContext = gameplayContext;
			_inputService = inputService;
			_gameFactory = gameFactory;
			_timeService = timeService;
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
		}

		private void InitializeInputSystems()
		{
			_inputSystems = new SystemsContainer();
			_inputSystems.Add(new InputFeature(_inputContext, _inputService));
		}

		private void InitializeGameplaySystems()
		{
			_gameplaySystems = new SystemsContainer();
			_gameplaySystems.Add(new InitializePlayerSystem(_gameFactory))
							.Add(new MovementFeature(_inputContext, _gameplayContext, _timeService));
		}
	}
}