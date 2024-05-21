using Asteroids.Scripts.Logic.Infrastructure.Services;

namespace Asteroids.Scripts.Unity.Infrastructure.Services
{
	public class UnityInputService : IInputService
	{
		public float HorizontalInput => _unityInputs.Game.Rotate.ReadValue<float>();
		public float VerticalInput => _unityInputs.Game.Move.ReadValue<float>();
		public bool IsFiring => _unityInputs.Game.Fire.IsPressed();

		private readonly UnityInputs _unityInputs = new();

		public void Initialize()
		{
			_unityInputs.Game.Enable();
		}
	}
}