using Asteroids.Scripts.Core.UI.Base;
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

		private void Start()
		{
			scoreElement.SetLabel("Score");
			positionElement.SetLabel("Position");
			rotationElement.SetLabel("Rotation");
			velocityElement.SetLabel("Velocity");
			velocityMagnitudeElement.SetLabel("Velocity M");
			laserCountElement.SetLabel("Laser");
			laserCooldownElement.SetLabel("Laser CD");
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
			scoreElement.SetValue(_screenModel.Score.ToString());
		}

		private void UpdateHints()
		{
			positionElement.SetValue(_screenModel.Position.ToString());
			rotationElement.SetValue(_screenModel.Rotation.ToString("F2"));
			velocityElement.SetValue(_screenModel.Velocity.ToString());
			velocityMagnitudeElement.SetValue(_screenModel.VelocityMagnitude.ToString("F2"));
			laserCountElement.SetValue($"{_screenModel.CurrentLaserCount} / {_screenModel.MaxLaserCount}");
			laserCooldownElement.SetValue(_screenModel.LaserCooldown.ToString("F2"));
		}
	}
}