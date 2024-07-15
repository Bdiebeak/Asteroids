using Asteroids.Scripts.Core.UI.Models;

namespace Asteroids.Scripts.Core.Infrastructure.StateMachine.States
{
	public class RestartState : BaseState
	{
		private readonly IGameStateMachine _stateMachine;
		private readonly GameScreenModel _gameScreenModel;
		private readonly GameOverScreenModel _gameOverScreenModel;

		public RestartState(IGameStateMachine stateMachine,
							GameScreenModel gameScreenModel, GameOverScreenModel gameOverScreenModel)
		{
			_stateMachine = stateMachine;
			_gameScreenModel = gameScreenModel;
			_gameOverScreenModel = gameOverScreenModel;
		}

		public override void Enter()
		{
			_gameScreenModel.Reset();
			_gameOverScreenModel.Reset();

			_stateMachine.Enter<GameLoopState>();
		}
	}
}