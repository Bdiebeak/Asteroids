namespace Asteroids.Scripts.Core.Utilities.Services.Input
{
	public interface IInputService
	{
		float MoveForward { get; }
		float Rotate { get; }
		bool WasPrimaryAttackPressedThisFrame { get; }
		bool WasSecondaryAttackPressedThisFrame { get; }
	}
}