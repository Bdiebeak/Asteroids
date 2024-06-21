using Asteroids.Scripts.Core.UI.Models;
using Asteroids.Scripts.DI.Resolver;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Scripts.Core.UI.Screens
{
	public class GameStartScreen : CanvasScreen
	{
		[SerializeField]
		private Button startButton;

		private StartScreenModel _screenModel;

		[Inject]
		public void Construct(StartScreenModel screenModel)
		{
			_screenModel = screenModel;
		}

		protected override void OnShown()
		{
			startButton.onClick.AddListener(OnStartButtonClicked);
		}

		protected override void OnClosed()
		{
			startButton.onClick.RemoveListener(OnStartButtonClicked);
		}

		private void OnStartButtonClicked()
		{
			_screenModel.StartGame();
		}
	}
}