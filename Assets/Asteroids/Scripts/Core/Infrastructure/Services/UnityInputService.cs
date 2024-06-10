namespace Asteroids.Scripts.Core.Infrastructure.Services
{
	public class UnityInputService : IInputService
	{
		public float HorizontalInput => _unityInputs.Game.Rotate.ReadValue<float>();
		public float VerticalInput => _unityInputs.Game.Move.ReadValue<float>();
		public bool IsFiringPressed => _unityInputs.Game.Fire.IsPressed();
		public bool IsStartLevelPressed => _unityInputs.Game.StartLevel.IsPressed();
		// public bool IsStartLevelPressed => _unityInputs.Game.St

		private readonly UnityInputs _unityInputs;

		public UnityInputService()
		{
			_unityInputs = new UnityInputs();
			_unityInputs.Game.Enable();
		}
	}
}