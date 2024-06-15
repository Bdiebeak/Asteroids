using Asteroids.Scripts.Core.UI.Base;
using Asteroids.Scripts.Core.UI.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Scripts.Core.UI.Screens
{
	public class StartScreen : CanvasScreen
	{
		[SerializeField]
		private Button _startButton;

		private StartScreenModel _screenModel;

		public void Construct(StartScreenModel screenModel)
		{
			_screenModel = screenModel;
		}

		protected override void OnShown()
		{
			_startButton.onClick.AddListener(OnStartButtonClicked);
			// TODO: refactoring.
			_screenModel.Enable();
		}

		protected override void OnClosed()
		{
			_startButton.onClick.RemoveListener(OnStartButtonClicked);
			// TODO: refactoring.
			_screenModel.Disable();
		}

		private void OnStartButtonClicked()
		{
			_screenModel.StartGame();
		}
	}
}