using System;
using UnityEngine.InputSystem;

namespace Asteroids.Scripts.Core.Infrastructure.Services.Input
{
	public class UnityInputService : IInputService
	{
		private readonly UnityInputs _unityInputs;

		public bool BulletAttack => _unityInputs.Game.BulletAttack.WasPressedThisFrame();
		public bool LaserAttack => _unityInputs.Game.LaserAttack.WasPressedThisFrame();
		public float MoveForward => _unityInputs.Game.MoveForward.ReadValue<float>();
		public float Rotate => _unityInputs.Game.Rotate.ReadValue<float>();
		public bool StartLevel => _unityInputs.Game.StartLevel.WasPressedThisFrame();

		public event Action StartLevelPressed;

		public UnityInputService()
		{
			_unityInputs = new UnityInputs();
			_unityInputs.Game.Enable();

			// TODO: unsubscribe?
			_unityInputs.Game.StartLevel.performed += OnStartLevelPerformed;
		}

		private void OnStartLevelPerformed(InputAction.CallbackContext obj)
		{
			StartLevelPressed?.Invoke();
		}
	}
}