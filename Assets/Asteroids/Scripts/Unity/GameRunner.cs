using Asteroids.Scripts.Logic.Infrastructure.StateMachine;
using Asteroids.Scripts.Logic.Infrastructure.StateMachine.States;
using UnityEngine;

namespace Asteroids.Scripts.Unity
{
	public class GameRunner : MonoBehaviour
	{
		private IGameStateMachine _gameStateMachine;

		private void Awake()
		{
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

		private void InitializeStateMachine()
		{
			_gameStateMachine = new GameStateMachine();
			_gameStateMachine.Register(new BootstrapState(_gameStateMachine));
			_gameStateMachine.Register(new GameInitializeState(_gameStateMachine));
			_gameStateMachine.Register(new GameLoopState(_gameStateMachine));
			_gameStateMachine.Register(new GameRestartState(_gameStateMachine));
		}
	}
}