namespace Asteroids.Scripts.Core.Utilities.Services.Input
{
	public class UnityInputService : IInputService
	{
		private readonly UnityInputs _unityInputs;

		public float MoveForward => _unityInputs.Game.MoveForward.ReadValue<float>();
		public float Rotate => _unityInputs.Game.Rotate.ReadValue<float>();
		public bool WasPrimaryAttackPressedThisFrame => _unityInputs.Game.PrimaryAttack.WasPressedThisFrame();
		public bool WasSecondaryAttackPressedThisFrame => _unityInputs.Game.SecondaryAttack.WasPressedThisFrame();

		public UnityInputService()
		{
			_unityInputs = new UnityInputs();
			_unityInputs.Game.Enable();
		}
	}
}