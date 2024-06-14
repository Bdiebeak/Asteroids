﻿using Asteroids.Scripts.Core.UI.Base;
using Asteroids.Scripts.Core.UI.ScreenModels;
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
		}

		protected override void OnClosed()
		{
			_restartButton.onClick.RemoveListener(OnRestartButtonClicked);
		}

		private void OnRestartButtonClicked()
		{
			_screenModel.Restart();
		}
	}
}