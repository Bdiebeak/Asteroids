using Asteroids.Scripts.Core.UI.Base;
using Asteroids.Scripts.Core.UI.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Scripts.Core.UI.Screens
{
	public class GameOverScreen : CanvasScreen
	{
		[SerializeField]
		private TextMeshProUGUI _scoreText;
		[SerializeField]
		private Button _restartButton;

		private GameOverScreenModel _screenModel;

		public void Construct(GameOverScreenModel screenModel)
		{
			_screenModel = screenModel;
		}

		protected override void OnShown()
		{
			_scoreText.SetText(_screenModel.Score.ToString());
			_restartButton.onClick.AddListener(OnRestartButtonClicked);
			// TODO: refactoring.
			_screenModel.Enable();
		}

		protected override void OnClosed()
		{
			_restartButton.onClick.RemoveListener(OnRestartButtonClicked);
			// TODO: refactoring.
			_screenModel.Disable();
		}

		private void OnRestartButtonClicked()
		{
			_screenModel.RestartGame();
		}
	}
}