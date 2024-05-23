using System;
using System.Collections.Generic;
using Asteroids.Scripts.Logic.Infrastructure.StateMachine.States;

namespace Asteroids.Scripts.Logic.Infrastructure.StateMachine
{
	public class GameStateMachine : IGameStateMachine
	{
		private readonly Dictionary<Type, IState> _states = new();

		public IState CurrentState { get; private set; }

		public void Register<TState>(TState state) where TState : IState
		{
			Type stateType = typeof(TState);
			_states[stateType] = state;
		}

		public void Enter<TState>() where TState : IState
		{
			CurrentState?.Exit();
			CurrentState = _states[typeof(TState)];
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