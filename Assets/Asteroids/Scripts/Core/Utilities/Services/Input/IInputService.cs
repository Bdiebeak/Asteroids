namespace Asteroids.Scripts.Core.Utilities.Services.Input
{
	public interface IInputService
	{
		bool BulletAttack { get; }
		bool LaserAttack { get; }
		float MoveForward { get; }
		float Rotate { get; }
	}
}