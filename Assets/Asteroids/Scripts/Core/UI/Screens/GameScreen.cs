using Asteroids.Scripts.Core.UI.Elements;
using Asteroids.Scripts.Core.UI.Models;
using Asteroids.Scripts.DI.Resolver;
using UnityEngine;

namespace Asteroids.Scripts.Core.UI.Screens
{
	public class GameScreen : CanvasScreen
	{
		[SerializeField]
		private LabelValueElement scoreElement;
		[SerializeField]
		private LabelValueElement positionElement;
		[SerializeField]
		private LabelValueElement rotationElement;
		[SerializeField]
		private LabelValueElement velocityElement;
		[SerializeField]
		private LabelValueElement velocityMagnitudeElement;
		[SerializeField]
		private LabelValueElement laserCountElement;
		[SerializeField]
		private LabelValueElement laserCooldownElement;

		private GameScreenModel _screenModel;

		[Inject]
		public void Construct(GameScreenModel screenModel)
		{
			_screenModel = screenModel;
		}

		private void Update()
		{
			// Here can be more complicated RX-system for Screen and ScreeModel communication.
			// But this values are updated very often and I decided to simply use Update function.
			UpdateScore();
			UpdateHints();
		}

		private void UpdateScore()
		{
			scoreElement.SetValue(_screenModel.score.ToString());
		}

		private void UpdateHints()
		{
			positionElement.SetValue(_screenModel.position.ToString());
			rotationElement.SetValue(_screenModel.rotation.ToString("F2"));
			velocityElement.SetValue(_screenModel.velocity.ToString());
			velocityMagnitudeElement.SetValue(_screenModel.velocityMagnitude.ToString("F2"));
			laserCountElement.SetValue($"{_screenModel.currentLaserCount} / {_screenModel.maxLaserCount}");
			laserCooldownElement.SetValue(_screenModel.laserCooldown.ToString("F2"));
		}
	}
}