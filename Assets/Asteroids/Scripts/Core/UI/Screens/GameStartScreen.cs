﻿using Asteroids.Scripts.Core.UI.Base;
using Asteroids.Scripts.Core.UI.Models;
using Asteroids.Scripts.DI.Resolver;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Scripts.Core.UI.Screens
{
	public class GameStartScreen : CanvasScreen
	{
		[SerializeField]
		private Button _startButton;

		private StartScreenModel _screenModel;

		[Inject]
		public void Construct(StartScreenModel screenModel)
		{
			_screenModel = screenModel;
		}

		protected override void OnShown()
		{
			_startButton.onClick.AddListener(OnStartButtonClicked);
			_screenModel.Enable();
		}

		protected override void OnClosed()
		{
			_startButton.onClick.RemoveListener(OnStartButtonClicked);
			_screenModel.Disable();
		}

		private void OnStartButtonClicked()
		{
			_screenModel.StartGame();
		}
	}
}