namespace Asteroids.Scripts.Core.Utilities.Services.Input
{
	public class UnityInputService : IInputService
	{
		private readonly UnityInputs _unityInputs;

		public bool BulletAttack => _unityInputs.Game.BulletAttack.WasPressedThisFrame();
		public bool LaserAttack => _unityInputs.Game.LaserAttack.WasPressedThisFrame();
		public float MoveForward => _unityInputs.Game.MoveForward.ReadValue<float>();
		public float Rotate => _unityInputs.Game.Rotate.ReadValue<float>();

		public UnityInputService()
		{
			_unityInputs = new UnityInputs();
			_unityInputs.Game.Enable();
		}
	}
}