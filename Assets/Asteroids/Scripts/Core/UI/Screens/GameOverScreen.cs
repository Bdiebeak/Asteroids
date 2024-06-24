﻿using Asteroids.Scripts.Core.UI.Models;
using Asteroids.Scripts.DI.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Scripts.Core.UI.Screens
{
	public class GameOverScreen : CanvasScreen
	{
		[SerializeField]
		private TextMeshProUGUI scoreText;
		[SerializeField]
		private Button restartButton;

		private GameOverScreenModel _screenModel;

		[Inject]
		public void Construct(GameOverScreenModel screenModel)
		{
			_screenModel = screenModel;
		}

		protected override void OnShown()
		{
			scoreText.SetText(_screenModel.score.ToString());
			restartButton.onClick.AddListener(OnRestartButtonClicked);
		}

		protected override void OnClosed()
		{
			restartButton.onClick.RemoveListener(OnRestartButtonClicked);
		}

		private void OnRestartButtonClicked()
		{
			_screenModel.RestartGame();
		}
	}
}