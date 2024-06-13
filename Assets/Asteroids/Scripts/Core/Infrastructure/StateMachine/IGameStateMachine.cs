﻿using Asteroids.Scripts.Core.Infrastructure.StateMachine.States;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine
{
	public interface IGameStateMachine
	{
		IState CurrentState { get; }
		void Register<TState>(TState state) where TState : IState;
		void Enter<TState>() where TState : IState;
		void Update();
		void Exit();
	}
}