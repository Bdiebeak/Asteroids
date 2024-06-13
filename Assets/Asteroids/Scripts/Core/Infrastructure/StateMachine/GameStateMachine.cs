using System;
using System.Collections.Generic;
using Asteroids.Scripts.Core.Infrastructure.Factories;
using Asteroids.Scripts.Core.Infrastructure.StateMachine.States;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine
{
	public class GameStateMachine : IGameStateMachine
	{
		private readonly IGameStatesFactory _statesFactory;
		private readonly Dictionary<Type, IState> _states = new();

		public IState CurrentState { get; private set; }

		public GameStateMachine(IGameStatesFactory statesFactory)
		{
			_statesFactory = statesFactory;
		}

		public void Register<TState>(TState state) where TState : IState
		{
			Type stateType = typeof(TState);
			_states[stateType] = state;
		}

		public void Enter<TState>() where TState : IState
		{
			Type newType = typeof(TState);
			if (_states.ContainsKey(newType) == false)
			{
				Register(_statesFactory.GetState<TState>());
			}

			CurrentState?.Exit();
			CurrentState = _states[newType];
			CurrentState.Enter();
		}

		public void Update()
		{
			CurrentState?.Update();
		}

		public void Exit()
		{
			CurrentState?.Exit();
			CurrentState = null;
			_states.Clear();
		}
	}
}